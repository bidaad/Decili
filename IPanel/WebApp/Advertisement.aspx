<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advertisement.aspx.cs" Title="تعرفه آگهی ویژه" MasterPageFile="~/MainRoot.Master" Inherits="Decili.Advertisement" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div id="contact" class="">
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp; </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="تعرفه آگهی ویژه"></asp:Label>
                </li>
            </ul>
        </div>

    </div>
    <div class="Clear">
    </div>
    <AKP:MsgBox runat="server" ID="msgBox" />
    <div class="panel panel-default Marginer20">
        <div class="panel-heading ListTitle">
            <h3 class="panel-title BulletList">تعرفه آگهی ویژه</h3>
        </div>
        <div class="Padder5">
            <div class="Padder20 RTL" >
                <ul class="Features">
                    <li>آگهی های ویژه در صفحه اول سایت به نمایش در میآیند</li>
                    <li>&nbsp;آگهی های ویژه در ابتدای نتایج جستجوی مرتبط دیده می شوند.</li>
                    <li>هنگام نمایش یگ آگهی ابتدا آگهی های ویژه همگروه با آن به نمایش در می 
		آیند و سپس آگهی های دیگر به ترتیب به روز شدن ظاهر می شوند.</li>
                    <li>
                    بدلیل نمایش آگهی های ویژه در صفحات متعدد سایت، این دسته آگهی ها 
	بیشتر مورد بازدید قرار میگیرند
                </li>
                     <li>
                    برای وزن دهی به آگهی های ویژه از معیار &quot;دسی&quot; استفاده می شود. آگهی هایی که 
	&quot;دسی&quot; بالاتری دارند، اولویت نمایش بیشتری دارند.
                </li>
                    <li>
                    هزینه آگهی ویژه را میتوانید بصورت آنلاین از طریق درگاه بانک پارسیان یا 
	ملی با هر کدام از کارتهای شتاب پرداخت کنید. کافی است رمز دوم کارت خود را با 
	خودپرداز تغییر دهید.
                </li>
                    <li>&nbsp;بنرهای تبلیغاتی در سایت دسیلی نمایش داده نمی‌شود. </li>
                </ul>
                
               
                <div>
                    <img src="images/DeciPrice.gif" class="img-responsive" />

                </div>
                
                
            </div>

            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
