using BlockChain.Share;
using System;
using System.Collections.Generic;
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
    /// WindowDeployment.xaml 的交互逻辑     注意：这个页面至少辅助测试使用！
    /// </summary>
    public partial class WindowDeployment : Window
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WindowDeployment()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            log.Info(this.GetType().ToString() + ", Width=" + this.Width.ToString() + "; Height=" + this.Height.ToString());
        }

        private async void Click_1(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcessing();
            try
            {
                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                if (null == ThisAccount)
                {
                    MessageBox.Show(this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.DutchAuction.ContractDefinition.DutchAuctionDeployment param = new Contract.DutchAuction.ContractDefinition.DutchAuctionDeployment()
                {
                    Admin = TextBoxAdmin1.Text,
                    Superadmin = TextBoxSuperAdmin1.Text,
                };
                var receipt = await Contract.DutchAuction.DutchAuctionService.DeployContractAndWaitForReceiptAsync(w3, param);
                log.Info("DutchAuctionDeployment:" + receipt.ContractAddress);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, receipt.TransactionHash, "DutchAuctionService.DeployContractAndWaitForReceiptAsync", "DutchAuctionService.DeployContractAndWaitForReceiptAsync");
                string text = Share.LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(receipt.TransactionHash);
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
                ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Click_2(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcessing();
            try
            {
                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                if (null == ThisAccount)
                {
                    MessageBox.Show(this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.BasicBusShareTokenFactory.ContractDefinition.BasicBusShareTokenFactoryDeployment param = new Contract.BasicBusShareTokenFactory.ContractDefinition.BasicBusShareTokenFactoryDeployment()
                {
                    Admin = TextBoxAdmin2.Text,
                    Superadmin = TextBoxSuperAdmin2.Text,
                    TokenDutchAuction = TextBoxTokenDutchAuction2.Text,
                };
                var receipt = await Contract.BasicBusShareTokenFactory.BasicBusShareTokenFactoryService.DeployContractAndWaitForReceiptAsync(w3, param);
                log.Info("BasicBusShareTokenFactoryDeployment:" + receipt.ContractAddress);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, receipt.TransactionHash, "BasicBusShareTokenFactoryService.DeployContractAndWaitForReceiptAsync", "BasicBusShareTokenFactoryService.DeployContractAndWaitForReceiptAsync");
                string text = Share.LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(receipt.TransactionHash);
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
                ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcesed();
                Cursor = Cursors.Arrow;
            }
        }

        private async void Click_3(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcessing();
            try
            {
                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                if (null == ThisAccount)
                {
                    MessageBox.Show(this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.DivShareTokenPairFactory.ContractDefinition.DivShareTokenPairFactoryDeployment param = new Contract.DivShareTokenPairFactory.ContractDefinition.DivShareTokenPairFactoryDeployment()
                {
                    Admin = TextBoxAdmin3.Text,
                    Superadmin = TextBoxSuperAdmin3.Text,
                };
                var receipt = await Contract.DivShareTokenPairFactory.DivShareTokenPairFactoryService.DeployContractAndWaitForReceiptAsync(w3, param);
                log.Info("DivShareTokenPairFactoryDeployment:" + receipt.ContractAddress);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, receipt.TransactionHash, "BasicBusShareTokenFactoryService.DeployContractAndWaitForReceiptAsync", "BasicBusShareTokenFactoryService.DeployContractAndWaitForReceiptAsync");
                string text = Share.LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(receipt.TransactionHash);
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
                ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private async void Click_4(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcessing();
            try
            {
                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                if (null == ThisAccount)
                {
                    MessageBox.Show(this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);
                Contract.Test.ContractDefinition.TestDeployment param = new Contract.Test.ContractDefinition.TestDeployment()
                {
                   Auction = this.TextBoxAuction.Text,
                  Sharetokenpair = this.TextBoxShareTokenPair.Text,
                };
                var receipt = await Contract.Test.TestService.DeployContractAndWaitForReceiptAsync(w3, param);
                log.Info("Test Deployment:" + receipt.ContractAddress);
                Share.BLL.TransactionReceipt.LogTx(ThisAccount.Address, receipt.TransactionHash, "TestService.DeployContractAndWaitForReceiptAsync", "TestService.DeployContractAndWaitForReceiptAsync");
                string text = Share.LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url = Share.ShareParam.GetTxUrl(receipt.TransactionHash);
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
                ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }

        private async void Click_0(object sender, RoutedEventArgs e)
        {

            this.Cursor = Cursors.Wait;
            ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcessing();
            try
            {
                var ThisAccount = Share.WindowAccount.GetAccount(this, new Share.BLL.Address());
                if (null == ThisAccount)
                {
                    MessageBox.Show(this, LanguageHelper.GetTranslationText("账号不存在，多半是密码错误导致。"));
                    return;
                }
                Nethereum.Web3.Web3 w3 = Share.ShareParam.GetWeb3(ThisAccount);

                var service1 = new Contract.DAIToken.DAITokenService(w3, "0x3f5ae1b947dd77d8efe017baf895f6a73cb29ee6");  // todo: 切记，这是写死的代码！
                var tx1 = await service1.TestMintRequestAsync();

                var service2 = new Contract.DAIToken.DAITokenService(w3, "0xFFE36E81aB2726f2ba65A6587FA9B7776D3F03a8");  // todo: 切记，这是写死的代码！  两个合约的 method 一样！
                var tx2 = await service2.TestMintRequestAsync();

                log.Info(tx1 + " - "+ tx2);
                string text = Share.LanguageHelper.GetTranslationText(@"交易已提交到以太坊网络，点击‘确定’查看详情。");
                string url1 = Share.ShareParam.GetTxUrl(tx1);
                string url2 = Share.ShareParam.GetTxUrl(tx2);
                if (MessageBox.Show(this, text, "Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", url1);
                    System.Diagnostics.Process.Start("explorer.exe", url2);
                }
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                ((BlockChain.Share.IMainWindow)(App.Current.MainWindow)).ShowProcesed();
                Cursor = Cursors.Arrow;
            }

        }


    }

}
