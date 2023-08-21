using BlockChain.Share;
using Nethereum.Hex.HexConvertors.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlockChain.ShareToken
{
    /// <summary>
    /// WindowAbout.xaml 的交互逻辑
    /// </summary>
    public partial class WindowAbout : Window
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WindowAbout()
        {
            InitializeComponent();
            this.Title = LanguageHelper.GetTranslationText(this.Title);

            TextBlockNotice.Text = LanguageHelper.GetTranslationText(Share.ShareParam.PrivacyAndSafeText);
            TextBlockDisclaimer.Text = LanguageHelper.GetTranslationText(ShareParam.DisclaimerText);

            //TabItemThanks.Visibility = Visibility.Hidden;   //感谢页面隐藏，没必要显示出来！

            log.Info(this.GetType().ToString() + ", Width=" + this.Width.ToString() + "; Height=" + this.Height.ToString());
        }

        private void WindowOnLoaded(object sender, RoutedEventArgs e)
        {
            //certutil -hashfile file.zip SHA256

            TabControl_SelectionChanged(TabControlMain, null);

            //LabelUs.Text = LanguageHelper.GetTranslationText(AboutUsText);

        }

        public static void ShowAbout(Window _owner)
        {
            WindowAbout w = new WindowAbout();
            w.Owner = _owner;
            w.ShowDialog();
        }

        private int PageIndex = -1;

        private async void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ((IMainWindow)Application.Current.MainWindow).ShowProcessing();
            try
            {
                if (PageIndex == TabControlMain.SelectedIndex)
                {
                    return;
                }
                PageIndex = TabControlMain.SelectedIndex;

                if (TabControlMain.SelectedIndex == 0)
                {
                    //处理当前版本
                    TextBlockCurVersion.Text =  ShareTokenParam.Version;

                    //处理最新版本信息，包括联系信息
                    //格式：平台（两位），时间（八位），chainid（六位），序号（三位），     
                    //      1020210323000004001 10 20210323 000004 001 代表windows版本，202123，rinkby网络，序号1 的版本

                    try
                    {
                        Nethereum.Web3.Web3 web3 = ShareParam.GetWeb3();
                        Share.Contract.AppInfo.AppInfoService service = new Share.Contract.AppInfo.AppInfoService(web3, ShareParam.AddressAppInfo);
                        var ContractInfo = await service.ContactInfoQueryAsync();
                        if (!string.IsNullOrEmpty(ContractInfo))
                        {
                            HyperlinkLinkInfo.Inlines.Clear();
                            try
                            {
                                HyperlinkLinkInfo.NavigateUri = new Uri(ContractInfo);
                            }
                            catch (Exception ex1)
                            {
                                log.Error("NavigateUri", ex1);
                            }
                            HyperlinkLinkInfo.Inlines.Add(ContractInfo);
                        }

                        var ProgramInfo = await service.CurAppVersionOfQueryAsync(ShareTokenParam.AppId, Share.BlockChainAppId.PlatformId);
                        var DownLoadInfo = await service.CurAppDownloadOfQueryAsync(ShareTokenParam.AppId, Share.BlockChainAppId.PlatformId);
                        if (null != ProgramInfo)
                        {
                            TextBlockLastVer.Text = ProgramInfo.Version.ToString();
                            TextBoxBT.Text = DownLoadInfo.BTLink;
                            TextBoxEd2k.Text = DownLoadInfo.EMuleLink;
                            TextBoxHttp.Text = DownLoadInfo.HttpLink;
                            TextBoxUpdateInfo.Text = ProgramInfo.UpdateInfo;
                            TextBoxSha256.Text = ProgramInfo.Sha256Value.ToHex(true);            //certutil -hashfile BlockChain.DividendToken.LOG.20200401.TXT SHA256
                            TextBoxIpfs.Text = DownLoadInfo.IpfsLink;
                            TextBoxSwarm.Text = DownLoadInfo.OtherLink;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("", ex);
                    }
                }
                else if (TabControlMain.SelectedIndex == 1)
                {
                    LableAppInfo.Content = ShareParam.AddressAppInfo;
                    //LabelBacth.Content = ShareParam.AddressAppInfo;
                    LabelShareTokenFactory.Content = ShareTokenParam.Address_ShareTokenFactory;
                    LabelDividendTokenExchange.Content = ShareTokenParam.Address_ShareTokenDexPairFactory;
                    LabelDutchAuction.Content = ShareTokenParam.AddressDutchAuction;

                }
                else if (TabControlMain.SelectedIndex == 2)
                {
                }

            }
            finally
            {
                ((IMainWindow)Application.Current.MainWindow).ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private void LabelContract_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Label)
            {
                var la = sender as Label;
                var ContractAddress = la.Content.ToString();
                var url = ShareParam.GetAddressUrl(ContractAddress);
                System.Diagnostics.Process.Start("explorer.exe", url);
            }
        }

        private void OnDownLoadBT(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxBT.Text))
            {
                System.Diagnostics.Process.Start("explorer.exe", TextBoxBT.Text);
            }
        }

        private void OnDownLoadeMule(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxEd2k.Text))
            {
                System.Diagnostics.Process.Start("explorer.exe", TextBoxEd2k.Text);
            }
        }

        private void OnClickTelegram(object sender, RoutedEventArgs e)
        {
            try
            {
                //不一定是telegram！
                string url = HyperlinkLinkInfo.NavigateUri.ToString();
                if (!string.IsNullOrEmpty(url))
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex) { log.Error("Contract Person Info", ex); }
        }

        private void OnDownLoadHttp(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxHttp.Text))
            {
                System.Diagnostics.Process.Start("explorer.exe", TextBoxHttp.Text);
            }
        }

        private void OnLinkClick(object sender, RoutedEventArgs e)
        {
            if (sender is Hyperlink)
            {
                Hyperlink link = sender as Hyperlink;
                Process.Start(new ProcessStartInfo(link.NavigateUri.AbsoluteUri));
            }
        }

        private void OnDownLoadTor(object sender, RoutedEventArgs e)
        {
            if (sender is Hyperlink)
            {
                Hyperlink link = sender as Hyperlink;
                Process.Start(new ProcessStartInfo(link.NavigateUri.AbsoluteUri));
            }
        }



        //private void OnClickDonation(object sender, RoutedEventArgs e)
        //{
        //    string to = LabelDonation.Content.ToString();
        //    WindowTransfer.DoTransfer(this, to);
        //}


    }
}
