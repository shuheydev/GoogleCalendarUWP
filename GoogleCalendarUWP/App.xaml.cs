﻿using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GoogleCalendarUWP;
using Windows.UI.Core;

namespace GoogleCalendarUWP
{
    /// <summary>
    /// 既定の Application クラスを補完するアプリケーション固有の動作を提供します。
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// 単一アプリケーション オブジェクトを初期化します。これは、実行される作成したコードの
        ///最初の行であるため、main() または WinMain() と論理的に等価です。
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// アプリケーションがエンド ユーザーによって正常に起動されたときに呼び出されます。他のエントリ ポイントは、
        /// アプリケーションが特定のファイルを開くために起動されたときなどに使用されます。
        /// </summary>
        /// <param name="e">起動の要求とプロセスの詳細を表示します。</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // ウィンドウに既にコンテンツが表示されている場合は、アプリケーションの初期化を繰り返さずに、
            // ウィンドウがアクティブであることだけを確認してください
            if (rootFrame == null)
            {
                // ナビゲーション コンテキストとして動作するフレームを作成し、最初のページに移動します
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: 以前中断したアプリケーションから状態を読み込みます
                }

                // フレームを現在のウィンドウに配置します
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // ナビゲーション スタックが復元されない場合は、最初のページに移動します。
                    // このとき、必要な情報をナビゲーション パラメーターとして渡して、新しいページを
                    //構成します
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // 現在のウィンドウがアクティブであることを確認します
                Window.Current.Activate();


                //2．タイトルバーの色変更
                //Window.Current。Activate()以降で行う必要がある。
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;

                //アクティブ時のタイトルバーの文字色、背景色の指定
                titleBar.ForegroundColor = Windows.UI.Colors.White;
                titleBar.BackgroundColor = Windows.UI.Color.FromArgb(0xff, 0x1d, 0xa1, 0xf2);

                //非アクティブ時のタイトルバーの文字色、背景色の指定
                titleBar.InactiveForegroundColor = Windows.UI.Colors.White;
                titleBar.InactiveBackgroundColor = Windows.UI.Color.FromArgb(0xff, 0x1d, 0xa1, 0xf2);

                //タイトルバーに付随の最大・最小化ボタン、閉じるボタンの文字色、背景色の指定
                titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
                titleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(0xff, 0x1d, 0xa1, 0xf2);

                //非アクティブ時のタイトルバーに付随の最大・最小化ボタン、閉じるボタンの文字色、背景色の指定
                titleBar.ButtonInactiveBackgroundColor = Windows.UI.Color.FromArgb(0xff, 0x1d, 0xa1, 0xf2);

                //マウスホバー時のタイトルバーに付随の最大・最小化ボタン、閉じるボタンの文字色、背景色の指定
                titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
                titleBar.ButtonHoverBackgroundColor = Windows.UI.Color.FromArgb(0xff, 0x1d, 0xca, 0xff);

                //システムの戻るボタンを表示
                //不要な場合はコメントアウトなど。
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            }
        }

        /// <summary>
        /// 特定のページへの移動が失敗したときに呼び出されます
        /// </summary>
        /// <param name="sender">移動に失敗したフレーム</param>
        /// <param name="e">ナビゲーション エラーの詳細</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// アプリケーションの実行が中断されたときに呼び出されます。
        /// アプリケーションが終了されるか、メモリの内容がそのままで再開されるかに
        /// かかわらず、アプリケーションの状態が保存されます。
        /// </summary>
        /// <param name="sender">中断要求の送信元。</param>
        /// <param name="e">中断要求の詳細。</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: アプリケーションの状態を保存してバックグラウンドの動作があれば停止します
            deferral.Complete();
        }
    }
}
