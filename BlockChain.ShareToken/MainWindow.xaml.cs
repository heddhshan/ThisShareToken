using BlockChain.Share;
using log4net;
using Nethereum.Contracts;
using Nethereum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlockChain.ShareToken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Share.IMainWindow
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region IMainWindow

        public void UpdateNodity(string info)
        {
            UcStatusBar.ShowInfo(info);
        }

        public void ShowProcessing(string msg = "Processing")
        {
            UcStatusBar.ShowProcessing(msg);
        }

        public void ShowProcesed(string msg = "Ready")
        {
            UcStatusBar.ShowProcesed(msg);
        }

        public void UpdateStartStatus()
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
        }

        public void UpdateFinalStatus()
        {
            ShowProcesed();
            Cursor = Cursors.Arrow;
        }


        public Share.MainWindowHelper GetHelper()
        {
            return Helper;
        }

        private bool _IsRunning = true;

        public bool GetIsRunning()
        {
            return _IsRunning;
        }

        #endregion

        private Share.MainWindowHelper Helper;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = Share.LanguageHelper.GetTranslationText(this.Title);
            Helper = new Share.MainWindowHelper(this);

            log.Info(this.GetType().ToString() + ", Width=" + this.Width.ToString() + "; Height=" + this.Height.ToString());
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                WindowPositionHelperConfig.SetSize(this);

                await UcStatusBar.UpdateInfo();             // 慢，影响界面显示
                UpdateNodity("Version: " + ShareTokenParam.Version);


                #region Token List Binding

                var TokenAView = Share.BLL.Token.GetAllSelectedToken().DefaultView;

                //兑换页面
                ComboBoxTokenSell.SelectedValuePath = "Address";            //token address
                ComboBoxTokenSell.ItemsSource = TokenAView;

                ComboBoxTokenBuy.SelectedValuePath = "Address";
                ComboBoxTokenBuy.ItemsSource = TokenAView;

                //ComboBoxTokenSell_1
                ComboBoxTokenSell_1.SelectedValuePath = "Address";            //token address
                ComboBoxTokenSell_1.ItemsSource = TokenAView;

                ComboBoxTokenBuy_1.SelectedValuePath = "Address";            //token address
                ComboBoxTokenBuy_1.ItemsSource = TokenAView;


                ComboBoxAuctionToken.SelectedValuePath = "Address";            //token address
                ComboBoxAuctionToken.ItemsSource = TokenAView;

                //ComboBoxDivToken23
                ComboBoxDivToken23.SelectedValuePath = "Address";            //token address
                ComboBoxDivToken23.ItemsSource = TokenAView;


                #endregion

                //从合约读取
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                Contract.DutchAuction.DutchAuctionService service = new Contract.DutchAuction.DutchAuctionService(w3, ShareTokenParam.AddressDutchAuction);
                var l = await service.LessPerBlocks1000QueryAsync();
                var b = await service.WaitBlocksQueryAsync();

                LabelLessPerBlocks.Content = ((decimal)l / 1000 * 100).ToString() + "%";
                LabelWaitBlocks.Content = b;

                #region Address List Binding

                var dv = new Share.BLL.Address().GetAllTxAddress();

                ComboBoxSeller.SelectedValuePath = "Address";              //user address
                ComboBoxSeller.ItemsSource = dv;




                #endregion


                log.Info("Window_Loaded");
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
                ShowProcesed();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowPositionHelperConfig.SaveSize(this);
        }

        private int PageIndex = -1;
        
        private void OnTabControlSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (PageIndex == TabControlMain.SelectedIndex)
                {
                    return;
                }

                if (TabControlMain.SelectedIndex == 0)
                {
                    ;
                }

                else if (TabControlMain.SelectedIndex == 1)
                {
                    ;
                }

                else if (TabControlMain.SelectedIndex == 2)
                {
                    ;
                }

                else if (TabControlMain.SelectedIndex == 3)
                {
                    TabControlMain.SelectedIndex = PageIndex;
                }

                PageIndex = TabControlMain.SelectedIndex;
            }
            catch (Exception ex)
            {
                log.Error("OnTabControlSelectionChanged", ex);
            }
        }


        #region 菜单

        private void OnTransfer(object sender, RoutedEventArgs e)
        {
            Share.WindowSimpleTransfer f = new WindowSimpleTransfer();
            f.Owner = this;
            f.ShowDialog();
        }

        private void Click_GoToAddress(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Content != null)
                {
                    var address = b.Content.ToString();
                    System.Diagnostics.Process.Start("explorer.exe", ShareParam.GetAddressUrl(address));
                }
            }
        }

        private void OnDeployment(object sender, RoutedEventArgs e)
        {
            WindowDeployment w = new WindowDeployment();
            w.Owner = this;
            w.ShowDialog();
        }

        //private void OnGotoTxId(object sender, RoutedEventArgs e)
        //{
        //    if (sender is Button)
        //    {
        //        Button b = (Button)sender;
        //        if (b.Content != null)
        //        {
        //            var tx = b.Content.ToString();
        //            System.Diagnostics.Process.Start("explorer.exe", ShareParam.GetTxUrl(tx));
        //        }
        //    }
        //}

        private void TagOnGotoAddress(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Tag != null)
                {
                    var address = b.Tag.ToString();
                    System.Diagnostics.Process.Start("explorer.exe", ShareParam.GetAddressUrl(address));
                }
            }
        }


        private void TagOnGotoTransactionHash(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Tag != null)
                {
                    var txid = b.Tag.ToString();
                    System.Diagnostics.Process.Start("explorer.exe", ShareParam.GetTxUrl(txid));
                }
            }
        }

        private void ButtonGameList_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAppInfo f = new WindowAppInfo();
            f.Owner = this;
            f.ShowDialog();
        }


        private void ButtonTools_OnClick(object sender, RoutedEventArgs e)
        {
            if (!MenuItemTools.IsSubmenuOpen)
            {
                MenuItemTools.IsSubmenuOpen = true;
            }
        }

        private void OnAddToken(object sender, RoutedEventArgs e)
        {
            Share.WindowToken.AddToken(this, new Share.BLL.Address());
        }


        private void OnTxExeStatus(object sender, RoutedEventArgs e)
        {
            Share.WindowTxStatus.ShowTxStatus(this);
        }

        private void OnAccountAddress(object sender, RoutedEventArgs e)
        {
            WindowAddressList.ShowAddressListTopmost(this);
        }


        private void OnWeb3Url(object sender, RoutedEventArgs e)
        {
            Share.WindowWeb3Test f = new Share.WindowWeb3Test();
            f.Owner = this;
            f.ShowDialog();
            MessageBox.Show(this, Share.LanguageHelper.GetTranslationText("如果修改了Web3链接，请重启。"), "Message", MessageBoxButton.OK);
        }

        private void OnDataBase(object sender, RoutedEventArgs e)
        {
            Share.WindowDbSet f = new Share.WindowDbSet();
            f.Owner = this;
            f.ShowDialog();
            MessageBox.Show(this, Share.LanguageHelper.GetTranslationText("如果修改了数据库链接，请重启。"), "Message", MessageBoxButton.OK);
        }

        private void OnLanguage(object sender, RoutedEventArgs e)
        {
            Share.WindowLanguage f = new Share.WindowLanguage();
            f.Owner = this;
            f.ShowDialog();
        }


        private void OnNotice(object sender, RoutedEventArgs e)
        {
            Share.WindowNotice.ShowWindowNotice(this, ShareTokenParam.AppId, new Share.BLL.Address());
        }


        private void OnAbout(object sender, RoutedEventArgs e)
        {
            WindowAbout.ShowAbout(this);
        }


        private void OnSysExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #endregion


        #region 拍卖

        private async void AuctionFilter_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                string TokenSell = "";
                string TokenBuy = "";
                if (ComboBoxTokenSell.SelectedValue != null) TokenSell = ComboBoxTokenSell.SelectedValue.ToString();
                if (ComboBoxTokenBuy.SelectedValue != null) TokenBuy = ComboBoxTokenBuy.SelectedValue.ToString();
                DataGridDutchAuctionSell.ItemsSource = await BLL.TokenDutchAuction.UpdateAndGetAuctionInfoList(ShareTokenParam.AddressDutchAuction, TokenSell, TokenBuy);
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void UpdateTime_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                var SI = DataGridDutchAuctionSell.SelectedItem;
            if (SI != null)
            {
                var model = (Model.DutchAuctionTokenSell)SI;
                await BLL.TokenDutchAuction.UpdateAuctionInfo(model, true);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private void OnBuyDutchAuctionToken(object sender, RoutedEventArgs e)
        {
            var SI = DataGridDutchAuctionSell.SelectedItem;
            if (SI != null)
            {
                var model = (Model.DutchAuctionTokenSell)SI;
                WindowDutchAuctionBuy.Buy(model, this);
            }
        }

        private async void DoDutchAuction(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                //荷兰拍卖                // function sell(address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount) external payable override WhenNotDelegateCall lock returns(bytes32 sellHash_)
                string tokenSell = ComboBoxTokenSell_1.SelectedValue.ToString();
                decimal tokenSellAmount = decimal.Parse(TextBoxSellTokenAmount.Text);
                string tokenBuy = ComboBoxTokenBuy_1.SelectedValue.ToString();
                decimal buyHighestAmount = decimal.Parse(TextBoxTokenBuyMaxAmount.Text);

                if (tokenSell.ToUpper() == tokenBuy.ToUpper())       //这个判断不太准确， 例如 0x0 和 0x0000000000000000000000 ； 这么处理也没问题，因为系统记录方法是一致的！
                {
                    MessageBox.Show(this, LanguageHelper.GetTranslationText(@"买币和卖币的Token不能一样！"));
                    return;
                }

                string address = ComboBoxSeller.SelectedValue.ToString();
                string password;
                if (!Share.WindowPassword.GetPassword(this, address, "Get Password", out password))
                {
                    MessageBox.Show(this, LanguageHelper.GetTranslationText(@"没有这个账号！"));
                    return;
                }

                //BigInteger BigTokenSellAmount = (BigInteger)((double)tokenSellAmount * Math.Pow(10, Share.BLL.Token.GetTokenDecimals(tokenSell)));
                BigInteger BigTokenSellAmount = Common.SolidityHelper.GetTokenBigIntAmount(tokenSellAmount, Share.BLL.Token.GetTokenDecimals(tokenSell));

                var Account = new Share.BLL.Address().GetAccount(address, password);
                if (Account == null) { MessageBox.Show(this, LanguageHelper.GetTranslationText(@"没有这个账号！")); return; }

                //approve !
                if (!ShareParam.IsAnEmptyAddress(tokenSell))
                {
                    bool IsOkApprove1 = await ((IMainWindow)App.Current.MainWindow).GetHelper().UiErc20TokenApprove(this, Account, tokenSell, ShareTokenParam.AddressDutchAuction, BigTokenSellAmount);
                    if (!IsOkApprove1)
                    {
                        MessageBox.Show(this, "Erc20 Token Approve Failed!");
                        return;
                    }
                }

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(Account);
                Contract.DutchAuction.DutchAuctionService service = new Contract.DutchAuction.DutchAuctionService(w3, ShareTokenParam.AddressDutchAuction);
                Contract.DutchAuction.ContractDefinition.SellFunction param = new Contract.DutchAuction.ContractDefinition.SellFunction()
                {
                    TokenSell = tokenSell,
                    TokenSellAmount = BigTokenSellAmount,
                    TokenBuy = tokenBuy,
                    //BuyHighestAmount = (BigInteger)((double)buyHighestAmount * Math.Pow(10, Share.BLL.Token.GetTokenDecimals(tokenBuy)))
                    BuyHighestAmount = Common.SolidityHelper.GetTokenBigIntAmount(buyHighestAmount , Share.BLL.Token.GetTokenDecimals(tokenBuy))

                };
                if (ShareParam.IsAnEmptyAddress(tokenSell))
                {
                    param.AmountToSend = BigTokenSellAmount;
                }

                var tx = await service.SellRequestAsync(param);

                Share.BLL.TransactionReceipt.LogTx(Account.Address, tx, "DutchAuction_Sell", "DutchAuction.Sell");
                string text = LanguageHelper.GetTranslationText(@"交易已经提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(tx);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }

            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private void ComboBoxSeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSellerBalance();        // 显示用户的 balance 
        }
        
        private async void ComboBoxTokenSell_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ComboBoxTokenSell_1.SelectedValue != null)
                {
                    ShowSellerBalance();    // 显示用户的 balance 

                    var TokenSell = ComboBoxTokenSell_1.SelectedValue.ToString();       //更新最小拍卖金额

                    LabelTokenSellMinAmount.Tag = (BigInteger)0;
                    LabelTokenSellMinAmount.Content = Share.LanguageHelper.GetTranslationText("查询中...");

                    Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                    Contract.DutchAuction.DutchAuctionService service = new Contract.DutchAuction.DutchAuctionService(w3, ShareTokenParam.AddressDutchAuction);
                    var bmin = await service.GetTokenSellMinSellQueryAsync(TokenSell);
                    LabelTokenSellMinAmount.Tag = bmin;
                    if (bmin == 0)
                    {
                        LabelTokenSellMinAmount.Content = Share.LanguageHelper.GetTranslationText("目前不支持此种Token的拍卖！");
                    }
                    else
                    {
                        //LabelTokenSellMinAmount.Content = (decimal)((double)bmin / Math.Pow(10, Share.BLL.Token.GetTokenDecimals(TokenSell)));
                        LabelTokenSellMinAmount.Content = Common.SolidityHelper.GetTokenDecimalAmount(bmin , Share.BLL.Token.GetTokenDecimals(TokenSell));
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowSellerBalance()
        {
            if (ComboBoxSeller.SelectedValue != null)                              //1， 有地址
            {
                var UserAddress = ComboBoxSeller.SelectedValue.ToString();
                LabelEthBalance.Content = Share.ShareParam.GetRealBalance(UserAddress, ShareParam.AddressEth);

                if (ComboBoxTokenSell_1.SelectedValue != null)
                {
                    var TokenSell = ComboBoxTokenSell_1.SelectedValue.ToString();
                    LabelTokenBalance.Content = Share.ShareParam.GetRealBalance(UserAddress, TokenSell);
                }
            }
        }

        private void TextBoxTokenBuyMaxAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // 计算价格 
                var TokenSellAmount = decimal.Parse(TextBoxSellTokenAmount.Text);
                var TokenBuyHighestAmount = decimal.Parse(TextBoxTokenBuyMaxAmount.Text);

                var price = TokenBuyHighestAmount / TokenSellAmount;
                LabelMaxPrice.Content = price;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
        }

        private void TextBoxSellTokenAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LabelTokenSellMinAmount.Tag != null)
            {
                var SellMin = (BigInteger)LabelTokenSellMinAmount.Tag;
                var SellAmount = decimal.Parse(TextBoxSellTokenAmount.Text);
                var TokenSell = ComboBoxTokenSell_1.SelectedValue.ToString();
                var BigSellAmount = (BigInteger)(SellAmount * (decimal)ShareParam.getPowerValue(Share.BLL.Token.GetTokenDecimals(TokenSell)));

                TextBoxSellTokenAmount.Foreground = new SolidColorBrush(Colors.Black);
                if (0 < SellMin)
                {
                    if (BigSellAmount < SellMin)
                    {
                        TextBoxSellTokenAmount.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    TextBoxSellTokenAmount.Foreground = new SolidColorBrush(Colors.Red);
                }
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }

        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        #region ShareToken

        private async void Click_SearchShareTokenList(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                //await BLL.BasShareTokenFactory.SynShareTokenNew();
                await BLL.BasShareTokenFactory.SynShareTokenAdd();

                string filter = TextBoxFilter10.Text.Trim();
                var list = await BLL.BasShareTokenFactory.GetShareTokenList(ShareTokenParam.Address_ShareTokenFactory);

                if (string.IsNullOrEmpty(filter))
                {
                    DataGridShareList.ItemsSource = list;
                }
                else
                {
                    var l = list.Where(x =>
                    {
                        var result = x.DivTokenAddress.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x.DivTokenSymbol.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x.ShareTokenName.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x.ShareTokenSymbol.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x._sender.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x.TransactionHash.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x._shareTokenAddrss.ToLower().IndexOf(filter.ToLower()) >= 0
                                    ;
                        return result;
                    });

                    DataGridShareList.ItemsSource = l;
                }

            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }


        }

        private async void Click_ShareTokenDetail(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBoxShareTokenAddress11.Text = (sender as Button).Tag.ToString();
                TabControlShareToken.SelectedIndex = 1;

                Click_QueryShareTokenDetail(null, null);
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }

        }

        private async void Click_QueryShareTokenDetail(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                var ShareToken = TextBoxShareTokenAddress11.Text;

                if (ShareToken == null || !new Nethereum.Util.AddressUtil().IsValidEthereumAddressHexFormat(ShareToken)) { TextBoxShareTokenAddress11.Focus(); return; }

                await BLL.BasShareToken.SynIconImage(ShareToken);

                ButtonShareTokenAddress11.Content = ShareToken; //todo

                var web3 = Share.ShareParam.GetWeb3();
                Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(web3, ShareToken);

                LabelName11.Content = await service.NameQueryAsync();
                LabelSymbol11.Content = await service.SymbolQueryAsync();

                //分红Token 的图标
                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                try
                {
                    var filepath = System.IO.Path.Combine(BasePath, BLL.BasShareToken.getShareTokenIcon(ShareToken));
                    Uri uri = new Uri(filepath, UriKind.Absolute);
                    BitmapImage bitmap = new BitmapImage(uri);
                    ImageIcon11.Source = bitmap;
                }
                catch (Exception ex)
                {
                    log.Error("", ex);
                }

                var d = await service.DecimalsQueryAsync();
                LabelDecimals11.Content = d;
                //LabelTotalSupply11.Content = (decimal)((double)await service.TotalSupplyQueryAsync() / Math.Pow(10, d));
                LabelTotalSupply11.Content = Common.SolidityHelper.GetTokenDecimalAmount(await service.TotalSupplyQueryAsync(), d);

                ButtonAdmin11.Content = await service.AdminQueryAsync();
                ButtonSupperAdmin11.Content = await service.SuperAdminQueryAsync();

                var DivToken = await service.DivTokenQueryAsync();
                ButtonDivSymbol11.Tag = DivToken;
                var DivModel = Share.BLL.Token.GetModel(DivToken);
                if (null == DivModel)
                {
                    await Share.BLL.Token.SaveTokenData(DivToken, @"TokenIcon\NoJPG.png", false);
                    DivModel = Share.BLL.Token.GetModel(DivToken);
                }
                DivModel.ImagePath = System.IO.Path.Combine(BasePath, DivModel.ImagePath);
                ButtonDivSymbol11.DataContext = DivModel;
                LabelSellToToken.DataContext = DivModel;

                var d1 = Share.BLL.Token.GetTokenDecimals(DivToken); 

                //LabelAccumulatedDistributedDivAmount.Content = (decimal)((double)await service.AccumulatedDistributedDivAmountQueryAsync() / Math.Pow(10, d1));
                LabelAccumulatedDistributedDivAmount.Content = Common.SolidityHelper.GetTokenDecimalAmount(await service.AccumulatedDistributedDivAmountQueryAsync(), d1);

                //LabelWaitingDivAmount.Content = (decimal)((double)await service.GetWaitingDivAmountQueryAsync() / Math.Pow(10, d1));
                LabelWaitingDivAmount.Content = Common.SolidityHelper.GetTokenDecimalAmount(await service.GetWaitingDivAmountQueryAsync(), d1);

                ButtonDutchAuction22.Content = await service.TokenDutchAuctionQueryAsync();

                // 分红列表
                DataGridDivHisList.ItemsSource = BLL.BasShareToken.GetShareTokenDivList(ShareToken).DefaultView;

                // 通知列表
                DataGridNoticeList.ItemsSource = BLL.BasShareToken.GetShareTokenNoticeList(ShareToken).DefaultView;

                var dv = new Share.BLL.Address().GetAllTxAddress();
                ComboBoxShareTokenAccount.SelectedValuePath = "Address";              //user address
                ComboBoxShareTokenAccount.ItemsSource = dv;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private void Click_GoToAddress2(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Content != null)
                {
                    var address = b.Tag.ToString();
                    System.Diagnostics.Process.Start("explorer.exe", ShareParam.GetAddressUrl(address));
                }
            }
        }

        private void OnGotoTxId(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Content != null)
                {
                    var tx = b.Content.ToString();
                    System.Diagnostics.Process.Start("explorer.exe", ShareParam.GetTxUrl(tx));
                }
            }
        }

        private void TagOnGotoTxId(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Tag != null)
                {
                    var tx = b.Tag.ToString();
                    System.Diagnostics.Process.Start("explorer.exe", ShareParam.GetTxUrl(tx));
                }
            }
        }

        private async void Click_Mint(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                //string TokenAddress = ButtonTokenAddress11.Content.ToString();
                if (ButtonShareTokenAddress11.Content == null) { return; }
                var ShareToken = ButtonShareTokenAddress11.Content.ToString();
                //var MintAmount = double.Parse(TextBoxMintAmount.Text) * Math.Pow(10, Share.BLL.Token.GetTokenDecimals(ShareToken));
                var MintAmount = Common.SolidityHelper.GetTokenBigIntAmount(decimal.Parse(TextBoxMintAmount.Text) ,Share.BLL.Token.GetTokenDecimals(ShareToken));

                var BigMintAmount = (System.Numerics.BigInteger)MintAmount;
                string Notice = TextBoxMintNotice.Text.Trim();
                string To = TextBoxMintToAddress.Text.Trim();

                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                if (null == ThisAccount)
                {
                    //MessageBox.Show (this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(w3, ShareToken);
                var txid = await service.MintRequestAsync(To, BigMintAmount, Notice);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "ShareToken_Mint", "ShareToken.mint");

                string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(txid);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Click_DistributeDividends(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null) { return; }
                string ShareToken = ButtonShareTokenAddress11.Content.ToString();
                string DivToken = ButtonDivSymbol11.Tag.ToString();

                //var BigDivAmount = double.Parse(TextBoxDivAmount.Text) * Math.Pow(10, Share.BLL.Token.GetTokenDecimals(DivToken));
                var BigDivAmount = Common.SolidityHelper.GetTokenBigIntAmount(decimal.Parse(TextBoxDivAmount.Text), Share.BLL.Token.GetTokenDecimals(DivToken));


                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                if (null == ThisAccount)
                {
                    //MessageBox.Show (this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }

                //1, 先 Appove                 //处理授权
                if (!Share.ShareParam.IsAnEmptyAddress(DivToken))
                {
                    bool IsOkApprove1 = await ((Share.IMainWindow)(this)).GetHelper().UiErc20TokenApprove(this, ThisAccount, DivToken, ShareToken, BigDivAmount);
                    if (!IsOkApprove1)
                    {
                        return;
                    }
                }

                //2, 再执行分红
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(w3, ShareToken);


                Contract.BasicBusShareToken.ContractDefinition.DistributeDividendsFunction param = new Contract.BasicBusShareToken.ContractDefinition.DistributeDividendsFunction()
                {
                    Amount = BigDivAmount,
                };
                if (Share.ShareParam.IsAnEmptyAddress(DivToken))
                {
                    param.AmountToSend = BigDivAmount;
                }
                var txid = await service.DistributeDividendsRequestAsync(param);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "ShareToken_Mint", "ShareToken.mint");

                string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(txid);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void ComboBoxShareTokenAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxShareTokenAccount.SelectedValue == null) { return; }
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null || ComboBoxShareTokenAccount.SelectedValue == null) { return; }
                var address = ComboBoxShareTokenAccount.SelectedValue.ToString();
                var ShareToken = ButtonShareTokenAddress11.Content.ToString();

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(w3, ShareToken);

                var DivToken = await service.DivTokenQueryAsync();
                var d = Share.BLL.Token.GetTokenDecimals(DivToken);
                var DivAount = (decimal)await service.DividendOfQueryAsync(address) / (decimal)ShareParam.getPowerValue(d);

                TextBoxAccountDivTokenAmount.Text = DivAount.ToString();
            }
            catch (Exception ex)
            {
                TextBoxAccountDivTokenAmount.Text = String.Empty;
                log.Error("", ex);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private async void Click_DutchAuction(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null || ComboBoxAuctionToken.SelectedValue == null) { return; }
                string ShareToken = ButtonShareTokenAddress11.Content.ToString();
                string SellToken = ComboBoxAuctionToken.SelectedValue.ToString();
                string DivToken = ButtonDivSymbol11.Tag.ToString();

                if (SellToken.ToLower() == DivToken.ToLower()) {
                    MessageBox.Show(Share.LanguageHelper.GetTranslationText("被拍卖的Token不能和分红Token一样！"), "Message");
                    return;
                }

                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(w3, ShareToken);
                Contract.BasicBusShareToken.ContractDefinition.SellTokenByAuctionFunction param = new Contract.BasicBusShareToken.ContractDefinition.SellTokenByAuctionFunction()
                {
                    TokenSell = SellToken,
                    //Gas = 3000000,
                };
                var txid = await service.SellTokenByAuctionRequestAsync(param);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "ShareToken_SellToken", "ShareToken.SellToken");

                string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(txid);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private void Click_SelectImageFile11(object sender, RoutedEventArgs e)
        {
            TextBoxIconImageFile11.Text = SelectFileWpf();
        }

        public string SelectFileWpf()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        private async void Click_SetIcon(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null) { return; }
                string ShareToken = ButtonShareTokenAddress11.Content.ToString();
                string ImageFileFullPath = TextBoxIconImageFile11.Text.Trim();
                string ImageFileName = System.IO.Path.GetFileName(ImageFileFullPath);       //得到文件短名称， 例如 abc.jpg
                var FileContext = System.IO.File.ReadAllBytes(ImageFileFullPath);

                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                //   var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address(), TextBoxAssetToken.Text, LabelAssetTokenSymbol.Content.ToString());

                if (null == ThisAccount)
                {
                    //MessageBox.Show (this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(w3, ShareToken);
                var txid = await service.SetIconRequestAsync(ImageFileName, FileContext);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "ShareToken_PublishNotice", "ShareToken.PublishNotice");

                string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(txid);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }
              
        private async void Click_ShareHisList(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null) { return; }
                string ShareToken = ButtonShareTokenAddress11.Content.ToString();// TextBoxShareTokenAddress11.Text;
                await BLL.BasShareToken.SynDividendsDistributed(ShareToken);
                DataGridDivHisList.ItemsSource = BLL.BasShareToken.GetShareTokenDivList(ShareToken).DefaultView;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Click_GetDivToken(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null || ComboBoxShareTokenAccount.SelectedValue == null) { return; }
                string ShareToken = ButtonShareTokenAddress11.Content.ToString();
                var UserAddress = ComboBoxShareTokenAccount.SelectedValue.ToString();

                string Password;
                if (!WindowPassword.GetPassword(this, UserAddress, "Get Password", out Password)) return;

                var ThisAccount = new Share.BLL.Address().GetAccount(UserAddress, Password);
                //if (ThisAccount == null) { MessageBox.Show(this, @"没有这个账号！"); return; }

                if (null == ThisAccount)
                {
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(w3, ShareToken);
                //function withdrawDividend() external returns(uint256 _dividendHeight);
                var txid = await service.WithdrawDividendRequestAsync();
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "TxUserMethod.ShareToken_WithdrawDividend", "ShareToken.WithdrawDividend");

                string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(txid);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Click_NoticeList(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null) { return; }
                string TokenAddress = ButtonShareTokenAddress11.Content.ToString();
                await BLL.BasShareToken.SynNoticePublish(TokenAddress);
                DataGridNoticeList.ItemsSource = BLL.BasShareToken.GetShareTokenNoticeList(TokenAddress).DefaultView;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }
        private async void Click_PublishNotice(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null) { return; }
                string TokenAddress = ButtonShareTokenAddress11.Content.ToString();
                string Notice = TextBoxCommonNotice.Text.Trim();

                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                //              var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address(), TextBoxAssetToken.Text, LabelAssetTokenSymbol.Content.ToString());
                if (null == ThisAccount)
                {
                    //MessageBox.Show (this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(w3, TokenAddress);
                var txid = await service.PublishNoticeRequestAsync(Notice);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "ShareToken_PublishNotice", "ShareToken.PublishNotice");

                string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(txid);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }
                
        private async void Click_CreateContract(object sender, RoutedEventArgs e)
        {

            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                //function newBasicBusShareToken(string calldata tokenName_, string calldata tokenSymbol_,
                //address divToken_, address admin_, address superAdmin_, string calldata _notice) external returns(address)
                Contract.BasicBusShareTokenFactory.ContractDefinition.NewBasicBusShareTokenFunction param = new Contract.BasicBusShareTokenFactory.ContractDefinition.NewBasicBusShareTokenFunction()
                {
                    Tokenname = TextBoxName.Text,
                    Tokensymbol= TextBoxSymbol.Text,
                    Divtoken = ComboBoxDivToken23.SelectedValue.ToString(),
                    Admin = TextBoxAdmin.Text,
                    Superadmin = TextBoxSuperAdmin.Text,
                    Notice = TextBoxNotice.Text.Trim(),
                };

                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                if (null == ThisAccount)
                {
                    //MessageBox.Show (this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.BasicBusShareTokenFactory.BasicBusShareTokenFactoryService service = new Contract.BasicBusShareTokenFactory.BasicBusShareTokenFactoryService(w3, ShareTokenParam.Address_ShareTokenFactory);

                log.Info("NewBasicBusShareTokenFunction" + Environment.NewLine + Newtonsoft.Json.JsonConvert.SerializeObject(param));
                var txid = await service.NewBasicBusShareTokenRequestAsync(param);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "ShareTokenFactory_NewShareToken", "ShareTokenFactory.NewShareToken");

                string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(txid);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Click_GetShareTokenInfo(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                await ShowShareTokenDetail();
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

            //this.Cursor = Cursors.Wait;
            //ShowProcessing();
            //try
            //{
            //    if (ButtonShareTokenAddress11.Content == null || ComboBoxShareTokenAccount.SelectedValue == null) { return; }
            //    var ShareToken = ButtonShareTokenAddress11.Content.ToString();
            //    var UserAddress = ComboBoxShareTokenAccount.SelectedValue.ToString();

            //    string Password;
            //    if (!WindowPassword.GetPassword(this, UserAddress, "Get Password", out Password)) return;

            //    var ThisAccount = new Share.BLL.Address().GetAccount(UserAddress, Password);
            //    //if (ThisAccount == null) { MessageBox.Show(this, @"没有这个账号！"); return; }

            //    if (null == ThisAccount)
            //    {
            //        return;
            //    }
            //    Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
            //    Contract.BasicBusShareToken.BasicBusShareTokenService service = new Contract.BasicBusShareToken.BasicBusShareTokenService(w3, ShareToken);
            //    //function withdrawDividend() external returns(uint256 _dividendHeight);
            //    var txid = await service.WithdrawDividendRequestAsync();
            //    Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "ShareToken_WithdrawDividend", "ShareToken.WithdrawDividend");

            //    string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
            //    string url = Share.ShareParam.GetTxUrl(txid);
            //    if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //    {
            //        System.Diagnostics.Process.Start("explorer.exe", url);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.Error("", ex);
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    ShowProcesed();
            //    Cursor = Cursors.Arrow;
            //}
        }

        private async void ComboBoxAuctionToken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                if (ButtonShareTokenAddress11.Content == null || ComboBoxAuctionToken.SelectedValue == null) { return; }
                var ShareToken = ButtonShareTokenAddress11.Content.ToString();
                string SellToken = ComboBoxAuctionToken.SelectedValue.ToString();

                LabelFromTokenAmount.Content = (decimal)ShareParam.GetRealBalance(ShareToken, SellToken, false);

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                Contract.DutchAuction.DutchAuctionService service = new Contract.DutchAuction.DutchAuctionService(w3, ShareTokenParam.AddressDutchAuction);
                var Big_MinSell = await service.GetTokenSellMinSellQueryAsync(SellToken);
                //LabelMinAuctionmount.Content =(decimal) ((double)Big_MinSell / Math.Pow(10, Share.BLL.Token.GetTokenDecimals(SellToken)));
                LabelMinAuctionmount.Content = Common.SolidityHelper.GetTokenDecimalAmount(Big_MinSell, Share.BLL.Token.GetTokenDecimals(SellToken));
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }



        #endregion


        #region Pair

        private int DexPageIndex = -1;

        private void TabControl0Dex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DexPageIndex == TabControl0Dex.SelectedIndex)
                {
                    return;
                }

                if (TabControl0Dex.SelectedIndex == 0)
                {
                    ;
                }

                else if (TabControl0Dex.SelectedIndex == 1)
                {
                    if (ButtonPair01.Content == null)
                    {

                        TabControl0Dex.SelectedIndex = DexPageIndex;
                    }
                }

                else if (TabControl0Dex.SelectedIndex == 2)
                {
                    ;
                }

                DexPageIndex = TabControl0Dex.SelectedIndex;
            }
            catch (Exception ex)
            {
                log.Error("TabControl0Dex_SelectionChanged", ex);
            }

        }

        private async void Click_SearchDivPairList(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                await BLL.DivShareTokenPairFactory.SynDivExPairNew();

                string filter = TextBoxFilter10.Text.Trim();
                var list = await BLL.DivShareTokenPairFactory.GetPairList();

                if (string.IsNullOrEmpty(filter))
                {
                    DataGridPairList.ItemsSource = list;
                }
                else
                {
                    var l = list.Where(x =>
                    {
                        var result = x.DivTokenAddress.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x.DivTokenSymbol.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x.ShareTokenName.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x.ShareTokenSymbol.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x._shareToken.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x._sender.ToLower().IndexOf(filter.ToLower()) >= 0
                                    || x._newPair.ToLower().IndexOf(filter.ToLower()) >= 0
                                    ;
                        return result;
                    });

                    DataGridPairList.ItemsSource = l;
                }

            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private async void Click_PairAddress(object sender, RoutedEventArgs e)
        {
            string Pair = (sender as Button).Tag.ToString();
            await ShowPair(Pair);
            TabControl0Dex.SelectedIndex = 1;

        }

        private async void Click_RefreshPair(object sender, RoutedEventArgs e)
        {
            string Pair = ButtonPair01.Content.ToString();
            await ShowPair(Pair);
        }


        private async Task<bool> ShowPair(string pair)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                ButtonPair01.Content = pair;

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(w3, pair);

                LabelIsPaused.Content = await service.PausedQueryAsync();

                var ShareToken = await service.ShareTokenQueryAsync();
                var DivToken = await service.DivTokenQueryAsync();

                //ButtonDivToken01.Tag = DivToken; ButtonDivToken01.ToolTip = DivToken;
                //ButtonAssToken01.Tag = AssToken; ButtonAssToken01.ToolTip = AssToken;
                //LabelDivToken01Symbol.Content = Share.BLL.Token.GetModel(DivToken).Symbol;
                //LabelAssToken01Symbol.Content = Share.BLL.Token.GetModel(AssToken).Symbol;
                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                var dm = Share.BLL.Token.GetModel(ShareToken);
                dm.ImagePath = System.IO.Path.Combine(BasePath, dm.ImagePath);
                StackPanelShareToken01.DataContext = dm;
                var am = Share.BLL.Token.GetModel(DivToken);
                am.ImagePath = System.IO.Path.Combine(BasePath, am.ImagePath);
                StackPanelDivToken01.DataContext = am;

                Nethereum.StandardTokenEIP20.StandardTokenService Erc20Service = new Nethereum.StandardTokenEIP20.StandardTokenService(w3, ShareToken);
                var Big_LiqShareAmount = await Erc20Service.BalanceOfQueryAsync(pair);
                //LiqShareAmount = LiqShareAmount / Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(ShareToken));
                var LiqShareAmount = Common.SolidityHelper.GetTokenDecimalAmount(Big_LiqShareAmount, Share.BLL.Token.GetTokenDecimals(ShareToken));

                LabelShareTokenLiq.Content = ((decimal)LiqShareAmount).ToString("N" + dm.Decimals.ToString());

                var Big_LiqDivAmount = await service.RealLiqDivAmountQueryAsync();
                //LiqDivAmount = LiqDivAmount / Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(DivToken));
                var LiqDivAmount = Common.SolidityHelper.GetTokenDecimalAmount(Big_LiqDivAmount, Share.BLL.Token.GetTokenDecimals(DivToken));

                LabelDivTokenLiq.Content =((decimal)LiqDivAmount).ToString("N" + am.Decimals.ToString());

                if (LiqShareAmount >0)
                {
                    LabelPrice0.Content = ((decimal)(LiqDivAmount / LiqShareAmount)).ToString("N9");
                }

                else
                {
                    LabelPrice0.Content = "???";
                }

                if (LiqDivAmount > 0)
                {
                    LabelPrice1.Content = ((decimal)(LiqShareAmount / LiqDivAmount)).ToString("N9");
                }
                else
                {
                    LabelPrice1.Content = "???";
                }

                var dv = new Share.BLL.Address().GetAllTxAddress();
                // 01 页面
                ComboBoxAddress01.SelectedValuePath = "Address";                //user address
                ComboBoxAddress01.ItemsSource = dv;

                await BLL.DivShareTokenPair.SynDividendsDistributed(pair);      //for test !!!

                return true;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }


        private void ComboBoxAddress01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExpanderSwap1.IsExpanded = false;
            ExpanderLiq2.IsExpanded = false;
            ExpanderDiv3.IsExpanded = false;

            if (ComboBoxAddress01.SelectedValue == null)
            {
                LabelAccountShareToken.Content = "Share Token:";
                LabelAccountDivToken.Content = "Div Token:";

                LabelAccountEth.Content = "";
                LabelAccountShare.Content = "";
                LabelAccountDiv.Content = "";

                return;
            }

            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                string address = ComboBoxAddress01.SelectedValue.ToString();
                string ShareToken = ButtonShareToken01.Tag.ToString();
                string DivToken = ButtonDivToken01.Tag.ToString();

                LabelAccountShareToken.Content = Share.BLL.Token.GetModel(ShareToken).Symbol + ":";
                LabelAccountDivToken.Content = Share.BLL.Token.GetModel(DivToken).Symbol + ":";

                LabelAccountEth.Content = Share.ShareParam.GetRealBalance(address, Share.ShareParam.EmptyAddress, false);
                LabelAccountShare.Content = Share.ShareParam.GetRealBalance(address, ShareToken, false);
                LabelAccountDiv.Content = Share.ShareParam.GetRealBalance(address, DivToken, false);
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Expanded_Swap1(object sender, RoutedEventArgs e)
        {
            string Pair = ButtonPair01.Content.ToString();

            //ExpanderSwap1.IsExpanded = true;
            ExpanderLiq2.IsExpanded = false;
            ExpanderDiv3.IsExpanded = false;

            if (ComboBoxFromToken.ItemsSource == null || ComboBoxFromToken.Tag.ToString().ToLower() != Pair.ToLower())
            {
                ComboBoxFromToken.Tag = Pair;
                ComboBoxFromToken.SelectedValuePath = "Address";
                ComboBoxFromToken.ItemsSource = GetPairDivToken();
            }
            await UpdateSwapInfo();
        }


        private List<Share.Model.Token> GetPairDivToken()
        // private async Task<List<Share.Model.Token>> GetDivAssToken()
        {
            List<Share.Model.Token> result = new List<Share.Model.Token>();
            try
            {
                string Pair = ButtonPair01.Content.ToString();

                string ShareToken = ButtonShareToken01.Tag.ToString();
                string DivToken = ButtonDivToken01.Tag.ToString();

                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                var m0 = Share.BLL.Token.GetModel(ShareToken);
                m0.ImagePath = System.IO.Path.Combine(BasePath, m0.ImagePath);
                result.Add(m0);

                var m1 = Share.BLL.Token.GetModel(DivToken);
                m1.ImagePath = System.IO.Path.Combine(BasePath, m1.ImagePath);
                result.Add(m1);
            }
            catch (Exception ex)
            {
                log.Info("", ex);

            }
            return result;
        }

        /// <summary>
        /// 刷新交易页信息
        /// </summary>
        /// <returns></returns>
        private async Task<bool> UpdateSwapInfo()
        {
            if (!ExpanderSwap1.IsExpanded)
            {
                return false;
            }

            if (ComboBoxFromToken.SelectedValue == null || ButtonToToken.Tag == null || ComboBoxAddress01.SelectedValue == null)
            {
                return false;
            }

            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                string Pair = ButtonPair01.Content.ToString();
                string UserAddress = ComboBoxAddress01.SelectedValue.ToString();

                string FromTokenAddress = ComboBoxFromToken.SelectedValue.ToString();
                string ToTokenAddress = ButtonToToken.Tag.ToString();

                //出价金额 
                System.Numerics.BigInteger AmountIn = 0;
                var AmountInDouble = double.Parse(TextBoxFromToken.Text);
                try
                {
                    AmountIn = (System.Numerics.BigInteger)(AmountInDouble * Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(FromTokenAddress)));
                }
                catch (Exception e1)
                {
                    log.Info("", e1);
                    return false;
                }

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(w3, Pair);

                var ShareToken = await service.ShareTokenQueryAsync();
                var DivToken = await service.DivTokenQueryAsync();

                Contract.DivShareTokenPair.ContractDefinition.GetSwapAmountOutFunction param = new Contract.DivShareTokenPair.ContractDefinition.GetSwapAmountOutFunction()
                {
                    AmountShareIn = 0,
                    AmountDivIn = 0,
                };
                if (ShareToken == FromTokenAddress || ShareToken.ToLower() == FromTokenAddress.ToLower())
                {
                    param.AmountShareIn = AmountIn;
                }
                else
                {
                    param.AmountDivIn = AmountIn;
                }

                var result = await service.GetSwapAmountOutQueryAsync(param); 

                var amount0 = (decimal)result.Amountshare / (decimal)Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(ShareToken));
                var amount1 = (decimal)result.Amountdiv / (decimal)Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(DivToken));
                var tokenIn = result.Tokenin;
                if (ShareToken == FromTokenAddress || ShareToken.ToLower() == FromTokenAddress.ToLower())
                {
                    var price0 = amount1 / amount0;
                    LabelPrice.Content = price0.ToString("N9"); ;
                    LabelToToken.Content = amount1;                 // AmountInDouble / price0;
                }
                else
                {
                    var price1 = amount0 / amount1;
                    LabelPrice.Content = price1.ToString("N9"); ;
                    LabelToToken.Content = amount0;                 // AmountInDouble / price1;
                }

                return true;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                return false;
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }


        private async void ComboBoxFromTokenOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string ShareToken = ButtonShareToken01.Tag.ToString();
                string DivToken = ButtonDivToken01.Tag.ToString();

                string Token = ComboBoxFromToken.SelectedValue.ToString();
                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;

                if (Token == ShareToken || Token.ToLower() == ShareToken.ToLower())
                {
                    var m = Share.BLL.Token.GetModel(DivToken);
                    m.ImagePath = System.IO.Path.Combine(BasePath, m.ImagePath);
                    ButtonToToken.DataContext = m;
                }
                else
                {
                    var m = Share.BLL.Token.GetModel(ShareToken);
                    m.ImagePath = System.IO.Path.Combine(BasePath, m.ImagePath);
                    ButtonToToken.DataContext = m;
                }

                await UpdateSwapInfo();
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
        }

        private async void TextBoxFromTokenOnLostFocus(object sender, RoutedEventArgs e)
        {
            await UpdateSwapInfo();
        }

        private async void ButtonSwapOnClick(object sender, RoutedEventArgs e)
        {
            if (ButtonPair01.Content == null || ComboBoxAddress01.SelectedValue  == null || ComboBoxFromToken.SelectedValue == null || ButtonToToken.Tag == null) { return; }

            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                string Pair = ButtonPair01.Content.ToString();
                string UserAddress = ComboBoxAddress01.SelectedValue.ToString();

                string FromTokenAddress = ComboBoxFromToken.SelectedValue.ToString();
                string ToTokenAddress = ButtonToToken.Tag.ToString();

                decimal FromTokenAmount = decimal.Parse(TextBoxFromToken.Text);
                decimal ToTokenAmount = (decimal)(LabelToToken.Content);
                decimal Diff100 = decimal.Parse(TextBoxSlippage.Text);
                decimal AddMinutes = decimal.Parse(TextBoxTxDeadline.Text);

                //double Price0 = double.Parse(LabelPrice0.Content.ToString());
                //double Price1 = double.Parse(LabelPrice1.Content.ToString());

                string Password;
                if (!WindowPassword.GetPassword(this, UserAddress, "Get Password", out Password)) return;

                var Account = new Share.BLL.Address().GetAccount(UserAddress, Password);
                if (Account == null) { MessageBox.Show(this, LanguageHelper.GetTranslationText(@"没有这个账号！")); return; }

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(Account);
                Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(w3, Pair);

                var ShareToken = await service.ShareTokenQueryAsync();
                var DivToken = await service.DivTokenQueryAsync();

                System.Numerics.BigInteger _amountShareIn = 0;
                System.Numerics.BigInteger _amountDivIn = 0;
                System.Numerics.BigInteger _amountMinShareOut = 0;
                System.Numerics.BigInteger _amountMinDivOut = 0;
                if (FromTokenAddress == ShareToken || FromTokenAddress.ToLower() == ShareToken.ToLower())       //使用分红token，交换资产token
                {
                    _amountShareIn = (System.Numerics.BigInteger)(FromTokenAmount * (decimal)ShareParam.getPowerValue(Share.BLL.Token.GetTokenDecimals(ShareToken)));      //decimal 有取值范围，这种写法某些情况下有错误！ 要是有 unit256 的 c# 类型
                    _amountDivIn = 0;
                    _amountMinShareOut = 0;
                    _amountMinDivOut = (System.Numerics.BigInteger)(ToTokenAmount * (decimal)ShareParam.getPowerValue(Share.BLL.Token.GetTokenDecimals(DivToken)) * (100 - Diff100) / 100);

                    bool IsOkApprove1 = await ((Share.IMainWindow)(this)).GetHelper().UiErc20TokenApprove(this, Account, ShareToken, Pair, _amountShareIn);
                    if (!IsOkApprove1)
                    {
                        return;
                    }
                }
                else //if (FromTokenAddress == DivToken || FromTokenAddress.ToLower() == DivToken.ToLower())       //使用资产token，交换分红token
                {
                    _amountShareIn = 0;
                    _amountDivIn = (System.Numerics.BigInteger)(FromTokenAmount * (decimal)ShareParam.getPowerValue(Share.BLL.Token.GetTokenDecimals(DivToken)));           //decimal 有取值范围，这种写法某些情况下有错误！ 要是有 unit256 的 c# 类型
                    _amountMinShareOut = (System.Numerics.BigInteger)(ToTokenAmount * (decimal)ShareParam.getPowerValue(Share.BLL.Token.GetTokenDecimals(ShareToken)) * (100 - Diff100) / 100);
                    _amountMinDivOut = 0;

                    if (!Share.ShareParam.IsAnEmptyAddress(DivToken))
                    {
                        bool IsOkApprove1 = await ((Share.IMainWindow)(this)).GetHelper().UiErc20TokenApprove(this, Account, DivToken, Pair, _amountDivIn);
                        if (!IsOkApprove1)
                        {
                            return;
                        }
                    }
                }

                var _deadline = Common.DateTimeHelper.ConvertDateTime2Int(System.DateTime.Now) + (long)(AddMinutes * 60);

                //function swap(
                //    uint256 _amountDivIn,
                //    uint256 _amountAssIn,
                //    uint256 _amountMinDivOut,
                //    uint256 _amountMinAssOut,
                //    uint256 _deadline
                //) external whenNotPaused lock returns(address tokenIn_, uint256 amountDiv_, uint256 amountAss_) {

                Contract.DivShareTokenPair.ContractDefinition.SwapFunction param = new Contract.DivShareTokenPair.ContractDefinition.SwapFunction()
                {
                    AmountShareIn = _amountShareIn,
                    AmountDivIn = _amountDivIn,
                    AmountMinShareOut = _amountMinShareOut,
                    AmountMinDivOut = _amountMinDivOut,
                    Deadline = _deadline,
                };
                if ((FromTokenAddress == DivToken || FromTokenAddress.ToLower() == DivToken.ToLower()) && Share.ShareParam.IsAnEmptyAddress(DivToken))
                {
                    param.AmountToSend = _amountDivIn;
                }

                var tx = await service.SwapRequestAsync(param);
                Share.BLL.TransactionReceipt.LogTx(Account.Address, tx, "DivExPair_Swap", "DivExPair.Swap");
                string text = LanguageHelper.GetTranslationText(@"交易已经提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(tx);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private async void Expanded_Liq2(object sender, RoutedEventArgs e)
        {
            ExpanderSwap1.IsExpanded = false;
            //ExpanderLiq2.IsExpanded = false;
            ExpanderDiv3.IsExpanded = false;

            await UpdateLiqInfo();
        }


        /// <summary>
        /// 刷新流动性页面
        /// </summary>
        /// <returns></returns>
        private async Task<bool> UpdateLiqInfo()
        {
            if (ButtonPair01.Content == null || ComboBoxAddress01.SelectedValue == null || ButtonShareToken01.Tag == null || ButtonDivToken01.Tag == null) { return false; }

            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                string Pair = ButtonPair01.Content.ToString();
                string UserAddress = ComboBoxAddress01.SelectedValue.ToString();
                string ShareToken = ButtonShareToken01.Tag.ToString();
                string DivToken = ButtonDivToken01.Tag.ToString();
                var Diff100 = double.Parse(TextBoxSlippageLiq.Text);

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(w3, Pair);

                //var LiqDivAmount = (double)await service.RealLiqDivAmountQueryAsync() / Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(DivToken));
                var LiqDivAmount =  Common.SolidityHelper.GetTokenDecimalAmount(await service.RealLiqDivAmountQueryAsync(), Share.BLL.Token.GetTokenDecimals(DivToken));

                Nethereum.StandardTokenEIP20.StandardTokenService Erc20Service = new Nethereum.StandardTokenEIP20.StandardTokenService(w3, ShareToken);

                //var LiqShareAmount = (double)await Erc20Service.BalanceOfQueryAsync(Pair) / Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(ShareToken));
                var LiqShareAmount = Common.SolidityHelper.GetTokenDecimalAmount(await Erc20Service.BalanceOfQueryAsync(Pair), Share.BLL.Token.GetTokenDecimals(ShareToken));

                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                var dm = Share.BLL.Token.GetModel(ShareToken);
                dm.ImagePath = System.IO.Path.Combine(BasePath, dm.ImagePath);
                var am = Share.BLL.Token.GetModel(DivToken);
                am.ImagePath = System.IO.Path.Combine(BasePath, am.ImagePath);

                if (TabControlLiq.SelectedIndex == 0)
                {
                    //增加流动性页面
                    ButtonTokenA.DataContext = dm;
                    ButtonTokenB.DataContext = am;

                    decimal AddShareAmount;
                    if (decimal.TryParse(TextBoxTokenA.Text, out AddShareAmount))
                    {
                        var AddDivAmoutMax = ((double)AddShareAmount * (double)LiqDivAmount * (100 + Diff100) / (double)LiqShareAmount) / 100;        //取最大值！
                        TextBoxTokenB.Text = AddDivAmoutMax.ToString("N" + am.Decimals.ToString());
                    }

                }
                else if (TabControlLiq.SelectedIndex == 1)
                {
                    //减少流动性页面
                    ButtonTokenAr.DataContext = dm;
                    ButtonTokenBr.DataContext = am;

                    var UserLiq = (double)await service.UserLiqValueOfQueryAsync(UserAddress);
                    var TotalLiqAmount = await service.TotalLiqValueQueryAsync();
                    SliderLiqR.Tag = UserLiq;                   // 这个值是准确的 BigInter 类型
                    SliderLiqR.Value = 100;

                    //记录用户的流动性 Token 数量
                    var ShareMax = (double)LiqShareAmount * (double)UserLiq / (double)TotalLiqAmount;           //2, 用户Token A 最大可取数量
                    var DivMax = (double)LiqDivAmount * (double)UserLiq / (double)TotalLiqAmount;               //3, 用户Token B 最大可取数量
                    TextBoxTokenAr.Tag = ShareMax;
                    TextBoxTokenBr.Tag = DivMax;

                    var ds = Share.BLL.Token.GetTokenDecimals(ShareToken);
                    var dd = Share.BLL.Token.GetTokenDecimals(DivToken);
                    TextBoxTokenAr.Text = ShareMax.ToString("N" + ds.ToString());
                    TextBoxTokenBr.Text = DivMax.ToString("N" + dd.ToString());

                    // 处理 分红的资产数量 减少流动性的时候要一起取出来！
                    //var Amount = (double)await service.DividendOfQueryAsync(UserAddress) / Math.Pow(10.0, dd);
                    var Amount = Common.SolidityHelper.GetTokenDecimalAmount(await service.DividendOfQueryAsync(UserAddress), dd);

                    TextBoxAssTokenAdd.Text = Amount.ToString();
                }

                return true;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                return false;
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private async void TextBoxTokenAOnLostFocus(object sender, RoutedEventArgs e)
        {
            await UpdateLiqInfo();
        }

        private void TextBoxSlippageLiq_LostFocus(object sender, RoutedEventArgs e)
        {
            //await UpdateLiqInfo();

            UpdateDivMax1();
        }

        private async void ButtonAddLiquidityOnClick(object sender, RoutedEventArgs e)
        {
            if (ButtonPair01.Content == null || ComboBoxAddress01.SelectedValue == null) { return; }

            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                string Pair = ButtonPair01.Content.ToString();
                string UserAddress = ComboBoxAddress01.SelectedValue.ToString();

                string Password;
                if (!WindowPassword.GetPassword(this, UserAddress, "Get Password", out Password)) return;

                var Account = new Share.BLL.Address().GetAccount(UserAddress, Password);
                if (Account == null) { MessageBox.Show(this, LanguageHelper.GetTranslationText(@"没有这个账号！")); return; }

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(Account);
                Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(w3, Pair);

                var ShareToken = await service.ShareTokenQueryAsync();
                var DivToken = await service.DivTokenQueryAsync();

                //function addLiquidity(
                //    uint _amountDiv,
                //    uint _amountAssMin,
                //    uint _amountAssMax
                //) external whenNotPaused lock payable returns(uint amountAss_, uint256 liq_) {

                //var _amountShare = double.Parse(TextBoxTokenA.Text) * Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(ShareToken));
                var _amountShare = Common.SolidityHelper.GetTokenBigIntAmount(decimal.Parse(TextBoxTokenA.Text), Share.BLL.Token.GetTokenDecimals(ShareToken));

                //var AmountDiv = double.Parse(TextBoxTokenB.Text) * Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(DivToken));
                var AmountDiv = Common.SolidityHelper.GetTokenBigIntAmount(decimal.Parse(TextBoxTokenB.Text), Share.BLL.Token.GetTokenDecimals(DivToken));

                var Diff100 = double.Parse(TextBoxSlippageLiq.Text);
                var _amountDivMin = (double)AmountDiv * (100 - Diff100) / (100 + Diff100);
                //var _amountAssMax = AmountAss * (100 + Diff100) / 100;        //不直观
                var _amountDivMax = AmountDiv;                                  //这样看起来直观点！

                double AddMinutes = double.Parse(TextBoxTxDeadlineLiq.Text);
                var _deadline = Common.DateTimeHelper.ConvertDateTime2Int(System.DateTime.Now) + (long)(AddMinutes * 60);

                Contract.DivShareTokenPair.ContractDefinition.AddLiquidityFunction param = new Contract.DivShareTokenPair.ContractDefinition.AddLiquidityFunction()
                {
                    AmountShare = (System.Numerics.BigInteger)_amountShare,
                    AmountDivMin = (System.Numerics.BigInteger)_amountDivMin,
                    AmountDivMax = (System.Numerics.BigInteger)_amountDivMax,
                    Deadline = _deadline,
                };

                if (Share.ShareParam.IsAnEmptyAddress(DivToken))
                {
                    param.AmountToSend = param.AmountDivMax;
                }
                else
                {
                    // 处理 ERC20 Approve 
                    bool IsOkApprove1 = await((Share.IMainWindow)(this)).GetHelper().UiErc20TokenApprove(this, Account, DivToken, Pair, param.AmountDivMax);
                    if (!IsOkApprove1)
                    {
                        return;
                    }
                }

                // 处理 ShareToken Approve 
                //bool IsOkApprove2 = await ((Share.IMainWindow)(this)).GetHelper().UiErc20TokenApprove(this, Account, DivToken, Pair, param.AmountDiv);
                bool IsOkApprove2 = await ((Share.IMainWindow)(this)).GetHelper().UiErc20TokenApprove(this, Account, ShareToken, Pair, param.AmountShare);
                if (!IsOkApprove2)
                {
                    return;
                }

                var tx = await service.AddLiquidityRequestAsync(param);
                Share.BLL.TransactionReceipt.LogTx(Account.Address, tx, "TxUserMethod.DivExPair_AddLiquidity", "DivExPair.AddLiquidity");
                string text = LanguageHelper.GetTranslationText(@"交易已经提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(tx);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }

            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private void SliderLiqR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (TextBoxTokenAr.Tag == null) { return; }
            try
            {
                string Pair = ButtonPair01.Content.ToString();
                string UserAddress = ComboBoxAddress01.SelectedValue.ToString();
                string ShareToken = ButtonShareToken01.Tag.ToString();
                string DivToken = ButtonDivToken01.Tag.ToString();

                var UserLiq = (double)SliderLiqR.Tag;

                double UserTokenAMax = (double)TextBoxTokenAr.Tag;         //2, 用户Token A 最大可取数量
                double UserTokenBMax = (double)TextBoxTokenBr.Tag;         //3, 用户Token B 最大可取数量

                if (UserLiq == 0 || UserTokenAMax == 0 || UserTokenBMax == 0)
                {

                    TextBoxTokenAr.Text = "0";
                    TextBoxTokenBr.Text = "0";

                    //LabelLiqR.Content = "0";
                    return;
                }

                var SelectValue = GetUserSelectedLiq();

                var da = Share.BLL.Token.GetTokenDecimals(ShareToken);
                var db = Share.BLL.Token.GetTokenDecimals(DivToken);

                var TokenAUser = (double)UserTokenAMax * (double)SelectValue / (double)UserLiq;
                var TokenBUser = (double)UserTokenBMax * (double)SelectValue / (double)UserLiq;

                TextBoxTokenAr.Text = TokenAUser.ToString("N" + da.ToString());
                TextBoxTokenBr.Text = TokenBUser.ToString("N" + db.ToString());

                LabelLiqR.Content = SliderLiqR.Value.ToString("N0");
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
        }

        private BigInteger GetUserSelectedLiq()
        {
            var liq = (double)SliderLiqR.Tag;
            var ul = SliderLiqR.Value;
            if (ul == SliderLiqR.Maximum)
            {
                return (BigInteger)liq;
            }
            return (BigInteger)(ul * (double)liq / 100.0);
        }

        private async void ButtonRemoveLiquidityOnClick(object sender, RoutedEventArgs e)
        {
            if (ComboBoxAddress01.SelectedValue == null || ButtonPair01.Content == null) { return; }

            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                string Pair = ButtonPair01.Content.ToString();
                string UserAddress = ComboBoxAddress01.SelectedValue.ToString();

                string Password;
                if (!WindowPassword.GetPassword(this, UserAddress, "Get Password", out Password)) return;

                var Account = new Share.BLL.Address().GetAccount(UserAddress, Password);
                if (Account == null) { MessageBox.Show(this, LanguageHelper.GetTranslationText(@"没有这个账号！")); return; }

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(Account);
                Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(w3, Pair);

                var ShareToken = await service.ShareTokenQueryAsync();
                var DivToken = await service.DivTokenQueryAsync();
                //var UserLiqAmount = service.UserLiqAmountOfQueryAsync(UserAddress);
                var SelectedLiqAmount = GetUserSelectedLiq();

                var Diff100 = double.Parse(TextBoxSlippageLiqR.Text);

                var _amountShareMin = double.Parse(TextBoxTokenAr.Text) * Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(ShareToken)) * (100 - Diff100) / 100;
                var _amountDivMin = double.Parse(TextBoxTokenBr.Text) * Math.Pow(10.0, Share.BLL.Token.GetTokenDecimals(DivToken)) * (100 - Diff100) / 100;

                double AddMinutes = double.Parse(TextBoxTxDeadlineLiqR.Text);
                var _deadline = Common.DateTimeHelper.ConvertDateTime2Int(System.DateTime.Now) + (long)(AddMinutes * 60);

                //function removeLiquidity(
                //    uint _liq,
                //    uint _amountDivMin,
                //    uint _amountAssMin,
                //    uint _deadline
                //) external lock returns(uint amountDiv_, uint amountAss_)
                Contract.DivShareTokenPair.ContractDefinition.RemoveLiquidityFunction param = new Contract.DivShareTokenPair.ContractDefinition.RemoveLiquidityFunction()
                {
                    Liq = SelectedLiqAmount,
                    AmountShareMin = (BigInteger)_amountShareMin,
                    AmountDivMin = (BigInteger)_amountDivMin,
                    Deadline = _deadline,
                };
                var tx = await service.RemoveLiquidityRequestAsync(param);
                Share.BLL.TransactionReceipt.LogTx(Account.Address, tx, "TxUserMethod.DivExPair_RemoveLiquidity", "DivExPair.RemoveLiquidity");
                string text = LanguageHelper.GetTranslationText(@"交易已经提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(tx);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Click_RefreshDivAmount(object sender, RoutedEventArgs e)
        {
            await UpdateDivAmount();
        }

        private async Task<bool> UpdateDivAmount()
        {
            try
            {
                string Pair = ButtonPair01.Content.ToString();

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(w3, Pair);

                if (ComboBoxAddress01.SelectedValue != null)
                {
                    string UserAddress = ComboBoxAddress01.SelectedValue.ToString();
                    //var DivToken = await service.DividendTokenQueryAsync();
                    var DivToken = await service.DivTokenQueryAsync();

                    var d = Share.BLL.Token.GetTokenDecimals(DivToken);
                    var Amount = (decimal)await service.DividendOfQueryAsync(UserAddress);
                    Amount = Amount  / (decimal)ShareParam.getPowerValue( d);           //如果没有流动性，这里会出异常
                    TextBoxDivAssAmount.Text = Amount.ToString();
                }
                else
                {
                    TextBoxDivAssAmount.Text = "***";
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                return false;
            }
        }

        private void TextBoxTokenB_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDivMax1();
        }

        private void UpdateDivMax1()
        {
            try
            {
                string s = TextBoxTokenB.Text;
                var amount = decimal.Parse(s);
                var Diff100 = decimal.Parse(TextBoxSlippageLiq.Text);

                var min = amount * (100 - Diff100) / (100 + Diff100);
                var tm = (Share.Model.Token)ButtonTokenB.DataContext;
                LabelTokenBMax.Content = min.ToString("N" + tm.Decimals.ToString());        // LabelTokenBMax 应该叫做 LabelTokenBMin
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
        }

        private async void Expanded_Div3(object sender, RoutedEventArgs e)
        {
            ExpanderSwap1.IsExpanded = false;
            ExpanderLiq2.IsExpanded = false;
            //ExpanderDiv3.IsExpanded = false;

            await UpdateDivAmount();
        }

        private async void Click_Div(object sender, RoutedEventArgs e)
        {
            if (ButtonPair01.Content == null || ComboBoxAddress01.SelectedValue == null) { return; }

            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                string Pair = ButtonPair01.Content.ToString();
                string UserAddress = ComboBoxAddress01.SelectedValue.ToString();

                string Password;
                if (!WindowPassword.GetPassword(this, UserAddress, "Get Password", out Password)) return;

                var Account = new Share.BLL.Address().GetAccount(UserAddress, Password);
                if (Account == null) { MessageBox.Show(this, LanguageHelper.GetTranslationText(@"没有这个账号！")); return; }

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(Account);
                Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(w3, Pair);
                var tx = await service.WithdrawDivTokenRequestAsync();
                Share.BLL.TransactionReceipt.LogTx(Account.Address, tx, "WithdrawDivToken", "DivExPair.WithdrawAssets");
                string text = LanguageHelper.GetTranslationText(@"交易已经提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(tx);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private async void LostFocus_DivToken02(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                await ShowShareTokenDetail();
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Click_NewPair(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ShowProcessing();
            try
            {
                var IsOk = await ShowShareTokenDetail();
                if (!IsOk)
                {
                    MessageBox.Show("Create Pair Failed");
                    return;
                }

                string ShareToken = LabelShareTokenAddress02.Content.ToString();
                string DivToken = ButtonDivSymbol02.Tag.ToString();
                int PowerM = int.Parse(TextBoxPowerM02.Text);

                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address(), DivToken, ButtonDivSymbol02.Content.ToString());
                if (null == ThisAccount)
                {
                    //MessageBox.Show (this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.DivShareTokenPairFactory.DivShareTokenPairFactoryService service = new Contract.DivShareTokenPairFactory.DivShareTokenPairFactoryService(w3, ShareTokenParam.Address_ShareTokenDexPairFactory);
                // function newDivExPair(address dividendToken_, uint256 powerM_) external returns (address) 
                var txid = await service.NewDivExPairRequestAsync(ShareToken, (byte)PowerM);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, txid, "TxUserMethod.DivExPairFactory_NewPair", "DivExPairFactory.NewDivExPair");
                string text = LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(txid);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }


        private async Task<bool> ShowShareTokenDetail()
        {
            string ShareToken = TextBoxShareToken02.Text;

            Nethereum.Util.AddressUtil AU = new Nethereum.Util.AddressUtil();
            if (!AU.IsValidEthereumAddressHexFormat(ShareToken))
            {
                return false;
            }               

            try
            {
                LabelShareTokenAddress02.Content = ShareToken;

                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3();
                Nethereum.StandardTokenEIP20.StandardTokenService ERC20TokenService = new Nethereum.StandardTokenEIP20.StandardTokenService(w3, ShareToken);

                LabelName02.Content = await ERC20TokenService.NameQueryAsync();
                LabelSymbol02.Content = await ERC20TokenService.SymbolQueryAsync();
                var d = await ERC20TokenService.DecimalsQueryAsync();
                //LabelTotalSupply02.Content = (decimal)((double)await ERC20TokenService.TotalSupplyQueryAsync() / Math.Pow(10, d));
                LabelTotalSupply02.Content = Common.SolidityHelper.GetTokenDecimalAmount(await ERC20TokenService.TotalSupplyQueryAsync(), d);

                LabelDecimals02.Content = d;

                Contract.IDivShareToken.IDivShareTokenService Service = new Contract.IDivShareToken.IDivShareTokenService(w3, ShareToken);
                var DivToken = await Service.DivTokenQueryAsync();
                if (Share.ShareParam.IsAnEmptyAddress(DivToken))
                {
                    ButtonDivSymbol02.Content = "ETH";
                    ButtonDivSymbol02.Tag = DivToken;
                    ButtonDivSymbol02.ToolTip = DivToken;
                    LabelDivDecimals02.Content = 18;
                }
                else
                {
                    Nethereum.StandardTokenEIP20.StandardTokenService AssetTokenService = new Nethereum.StandardTokenEIP20.StandardTokenService(w3, DivToken);
                    ButtonDivSymbol02.Content = await AssetTokenService.SymbolQueryAsync();
                    ButtonDivSymbol02.Tag = DivToken;
                    ButtonDivSymbol02.ToolTip = DivToken;
                    LabelDivDecimals02.Content = await AssetTokenService.DecimalsQueryAsync();
                }

                // function getDivRecommendedDecimals(address tokenAssetToken_) external view returns (uint8) 
                Contract.DivShareTokenPairFactory.DivShareTokenPairFactoryService PairFactoryService = new Contract.DivShareTokenPairFactory.DivShareTokenPairFactoryService(w3, ShareTokenParam.Address_ShareTokenDexPairFactory);
                //PairFactoryService.GetPairRecommendedPowerMQueryAsync
                var dm = await PairFactoryService.GetPairRecommendedPowerMQueryAsync(ShareToken);
                LabelRecommendedPowerM02.Content = dm;
                //TextBoxPowerM02.Text = dm.ToString();

                return true;
            }
            catch (Exception ex)
            {
                LabelShareTokenAddress02.Content = ShareToken + " : " + ex.Message;
                log.Error("", ex);
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private async void TabControlLiq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await UpdateLiqInfo();
        }

        #endregion

        
    }

}
