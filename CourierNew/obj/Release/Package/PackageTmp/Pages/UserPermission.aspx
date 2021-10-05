<%@ Page Title="User Permission" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="UserPermission.aspx.cs" Inherits="CourierNew.Pages.UserPermission" %>

<asp:Content ID="C1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Register Src="~/UserControl/ctrBtn.ascx" TagPrefix="uc1" TagName="ctrBtn" %>
<asp:Content ID="C2" ContentPlaceHolderID="CP1" runat="server">

       <span class="hidden">
        SQL_Save: UserPermissionUpdate
        SQL_Get:  UserPermissionGet
    </span>

<%--    <script src="../Scripts/bs.pagination.js"></script>--%>
    <script src="Js/UserPermissionEntry.js?ver=2"></script>
    <!------------------Step 1 Set Page Size----->
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('User Permission');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '550px';
            }

            window.parent.$("#MainModel").addClass('modal-xl');
        }

    </script>
    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>


    <div class="add-btn btntop card fixed-top p-1 text-right">
        <TopButton:Buttons runat="server" ID="btnTop" OnMasterEve="Buttons_MasterEve" VisibleCancel="false" VisibleSave="true" VisibleAddnew="false" VisibleDelRecord="false" enRole="UserPermission" />

    </div>
    <!------------------Step 2 Page Design------->
    <!------------------Step 2 Page Design------->
    <section class="content" style="margin-top: 50px">
        <div class="card-header">
         
                <div class="row col-lg-12 form-group">

                     <label>Module</label>
                       <div class="form-group col-lg-3">
                        
                        <asp:DropDownList ID="ddlModule" runat="server" AppendDataBoundItems="True" CssClass="form-control  ddlCategoryName" placeholder="Role"  AutoPostBack="True"
                            OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                            <asp:ListItem Text="Select" Value="-1" />
                        </asp:DropDownList>
                    </div>

                   <asp:Label ID="lblModule" CssClass="col-1 hidden" runat="server">Module</asp:Label>
                    <div class="col-lg-3">
                        <asp:DropDownList ID="ddlModule1" runat="server" CssClass="form-control col-10 hidden"
                            Width="200px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" AppendDataBoundItems="true">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                   
                    <asp:Label ID="lblRolePermissionFor" CssClass=" text-bold text-maroon" runat="server"></asp:Label>

                    <div class="col-lg-1">
                        <asp:Button ID="btnCatcheClear" OnClick="btnCatcheClear_Click" runat="server" CssClass="btn btn-primary pull-right" Text="Remove Cache" Visible="false" />

                    </div>

                </div>
                <div class="row">
                    <span class="text-muted pad">After selecting role. Select module to view/change role premission.</span>
                </div>

                <div class="col-lg-12">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"
                        PagerStyle-CssClass="pager" FooterStyle-CssClass="tfoot" CssClass="gvrole table table-bordered table-sm" AllowPaging="false" DataKeyNames="MenuID,PermissionKey"
                        AllowSorting="True" EnableViewState="true" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="MenuName" HeaderText="Page/Functionality"
                                SortExpression="MenuName"></asp:BoundField>
                            <asp:TemplateField HeaderText="Add" HeaderStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    Add 
                                    <br />
                                    <asp:CheckBox ID="chkAddAlladd" onchange="CheckAll('add',this)" CssClass="addAll text-bold" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAdd" CssClass="add" runat="server" Checked='<%# Eval("Add") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit"  HeaderStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    Edit 
                                    <br />
                                    <asp:CheckBox ID="chkAddAlledit" onchange="CheckAll('edit',this)" CssClass="addAll text-bold" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEdit" CssClass="edit" runat="server" Checked='<%# Eval("Edit") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete"  HeaderStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    Delete 
                                    <br />
                                    <asp:CheckBox ID="chkAddAlldelete" onchange="CheckAll('delete',this)" CssClass="addAll text-bold" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkDelete" runat="server" CssClass="delete" Checked='<%# Eval("Delete") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View"  HeaderStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    View 
                                    <br />
                                    <asp:CheckBox ID="chkAddAllview" onchange="CheckAll('view',this)" CssClass="addAll text-bold" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkView" runat="server" CssClass="view" Checked='<%# Eval("View") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View Log"  HeaderStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    View Log
                                    <br />
                                    <asp:CheckBox ID="chkAddAllviewlog" onchange="CheckAll('viewlog',this)" CssClass="addAll text-bold" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkViewLog" runat="server" CssClass="viewlog" Checked='<%# Eval("ViewLog") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Print"  HeaderStyle-CssClass="text-center">
                                <HeaderTemplate>
                                    Print
                                    <br />
                                    <asp:CheckBox ID="chkAddAllprint" onchange="CheckAll('print',this)" CssClass="addAll text-bold" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPrint" CssClass="print" runat="server" Checked='<%# Eval("Print") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="Numeric" Position="Bottom" />
                        <FooterStyle CssClass="tfoot"></FooterStyle>
                        <PagerStyle CssClass="bs-pagination" />
                    </asp:GridView>
                </div>



                <%--		<asp:TextBox ID="txtKey" Text="0" runat="server"  CssClass="hidden" ></asp:TextBox>--%>
                <asp:TextBox ID="txtRoleName" Text="Select Role" runat="server" CssClass="hidden myrole"></asp:TextBox>
                <asp:HiddenField runat="server" ID="hdCacheClear" Value="0" />

            </div>
     
    </section>
</asp:Content>
