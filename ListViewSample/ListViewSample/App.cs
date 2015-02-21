using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ListViewSample {
    public class App : Application {
        public App() {
            MainPage = new MyPage();
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }

    class MyPage : ContentPage {

        
        // 3.テキストのみのリストビュー     
        // 4.セルの高さの指定 
        public MyPage() {

            //「item-数字」の形式で100行を生成する
            var ar = new ObservableCollection<String>();
            foreach (var i in Enumerable.Range(0, 100)) {
                ar.Add(string.Format("item-{0}", i));
            }
            //リストビューを生成する
            var listView = new ListView {
                ItemsSource = ar, //ソースを指定する
                //RowHeight = 30, // セルの高さ指定
            };

            Content = new StackLayout {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0), //iOSのみ上部にマージンをとる
                Children = {listView}
            };
        }
        
        /*
        // 5.スクロール 
        public MyPage() {
            //「item-数字」の形式で100行を生成する
            var ar = new ObservableCollection<String>();
            foreach (var i in Enumerable.Range(0, 100)) {
                ar.Add(string.Format("item-{0}", i));
            }
            //リストビューを生成する
            var listView = new ListView {
                ItemsSource = ar //ソースを指定する
            };

            const int index = 20; //ターゲットを20番目の行にする
            ar[index] += " target"; //ターゲットの文字列を修正する

            var buttonStart = new Button {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Start",
                //ターゲットが先頭行に表示されるようにスクロールする
                Command = new Command(() => { listView.ScrollTo(ar[index], ScrollToPosition.Start, true); })
            };
            var buttonEnd = new Button {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "End",
                //ターゲットが最終行に表示されるようにスクロールする
                Command = new Command(() => { listView.ScrollTo(ar[index], ScrollToPosition.End, true); })
            };
            var buttonCenter = new Button {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Center",
                //ターゲットが中間付近に表示されるようにスクロールする
                Command = new Command(() => { listView.ScrollTo(ar[index], ScrollToPosition.Center, true); })
            };
            var buttonMakeVisible = new Button {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "MakeVisible",
                //ターゲットが表示されるまでスクロールする
                Command = new Command(() => { listView.ScrollTo(ar[index], ScrollToPosition.MakeVisible, true); })

            };
            Content = new StackLayout {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0), //iOSのみ上部にマージンをとる
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal, //横に並べる
                        Children = {
                            //４つのボタンを追加
                            buttonStart,
                            buttonEnd,
                            buttonCenter,
                            buttonMakeVisible
                        }
                    },
                    listView
                }
            };
        }
        */

        /*
        // 6.テキストと画像のリストビュー
        class Data {
            public String Name { get; set; }
            public String Phone { get; set; }
            public String Icon { get; set; }
        }
        public MyPage() {

            //「item-数字」の形式で100行を生成する
            //ダミーの個人情報は、「http://ja.fakenamegenerator.com/gen-random-us-us.php」で作成した
            var ar = new ObservableCollection<Data>();
            ar.Add(new Data {Name = "Brent M. Soltis", Phone = "601-400-3356", Icon = "man.png"});
            ar.Add(new Data {Name = "Joel K. Coffey", Phone = "360-403-0486", Icon = "man.png"});
            ar.Add(new Data {Name = "Rhonda J. Bailey", Phone = "801-617-8209", Icon = "woman.png"});
            ar.Add(new Data {Name = "Elizabeth E. McClellan", Phone = "415-771-0336", Icon = "woman.png"});
            ar.Add(new Data {Name = "Michael H. White", Phone = "620-625-0916", Icon = "man.png"});


            //テンプレートの作成(ImageCell使用)
            var cell = new DataTemplate(typeof (ImageCell));
            cell.SetBinding(ImageCell.TextProperty, "Name"); //上段のテキスト
            cell.SetBinding(ImageCell.DetailProperty, "Phone"); //下段のテキスト
            cell.SetBinding(ImageCell.ImageSourceProperty, "Icon"); //画像

            //リストビューを生成する
            var listView = new ListView {
                ItemsSource = ar, //ソースを指定する
                ItemTemplate = cell //テンプレート指定
            };

            Content = new StackLayout {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0), //iOSのみ上部にマージンをとる
                Children = {listView}
            };
        }
        */
        /*
        //7.グループ表示
        private class Data {
            public String Name { get; set; }
            public String Phone { get; set; }
            public String Icon { get; set; }
        }
        
        //１つのグループを表現するクラス
        private class Group : ObservableCollection<Data> {
            public string Title { get; set; } //グループ用のタイトル

            public Group(string title) {
                Title = title;
            }
        }

        public MyPage() {

            //現姓と女性にグループ分けしてデータを作成
            var ar = new ObservableCollection<Group> {
                new Group("Man") {
                    new Data {Name = "Brent M. Soltis", Phone = "601-400-3356", Icon = "man.png"},
                    new Data {Name = "Joel K. Coffey", Phone = "360-403-0486", Icon = "man.png"},
                    new Data {Name = "Michael H. White", Phone = "620-625-0916", Icon = "man.png"}
                },
                new Group("Woman") {
                    new Data {Name = "Rhonda J. Bailey", Phone = "801-617-8209", Icon = "woman.png"},
                    new Data {Name = "Elizabeth E. McClellan", Phone = "415-771-0336", Icon = "woman.png"},
                }
            };

            //テンプレートの作成(ImageCell使用)
            var cell = new DataTemplate(typeof (ImageCell));
            cell.SetBinding(ImageCell.TextProperty, "Name"); //上段のテキスト
            cell.SetBinding(ImageCell.DetailProperty, "Phone"); //下段のテキスト
            cell.SetBinding(ImageCell.ImageSourceProperty, "Icon"); //画像

            //リストビューの生成
            var listView = new ListView {
                ItemsSource = ar, //ソースを指定する
                ItemTemplate = cell, //テンプレート指定
                IsGroupingEnabled = true, //グループ表示有効(追加)
                GroupDisplayBinding = new Binding("Title"), //グループのタイトル指定(追加)
            };


            Content = new StackLayout {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0), //iOSのみ上部にマージンをとる
                Children = {listView}
            };

        }
        */
    }

}



