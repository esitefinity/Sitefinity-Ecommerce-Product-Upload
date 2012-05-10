<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CsvUploader.ascx.cs" Inherits="SitefinityWebApp.ProductsUpload.CsvUploader" %>
<h1 class="sfBreadCrumb" id="sfToMainContent">
    <span>Product Upload:</span></h1>
<div class="sfMain sfClearfix">
    <div class="sfContent">
        <div class="sfAllToolsWrapper">
            <div class="sfAllTools">
                <%--<ul id="commandButtons" class="sfActions">
                    <li class="sfMainAction"></li>
                </ul>--%>
            </div>
        </div>
        <div class="sfWorkArea">
            <div id="messageControl" runat="server" class="sfMessage sfGridViewMessage">
            </div>
            <div>
                <h2>
                    Upload Csv File</h2>
                <br />
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RequiredFieldValidator ID="rq4" runat="server" ControlToValidate="FileUpload1"
                    ErrorMessage="* Required" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"
                    ValidationGroup="UploadCSV"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexValidator" runat="server" ControlToValidate="FileUpload1"
                    ErrorMessage="Only CSV file is allowed" ValidationGroup="UploadCSV" ValidationExpression="(.*\.([Cc][Ss][Vv])$)">
                </asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:Button ID="btnUpload" runat="server" ValidationGroup="UploadCSV" Text="Submit"
                    CssClass="RadUploadSubmit" OnClick="btnUpload_Click" />
            </div>
        </div>
    </div>
</div>