<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrRefTable.ascx.cs" Inherits="CourierNew.UserControl.CtrRefTable" %>
<script src="../UserControl/Js/RefTableSearch.js"></script>
<section class="content">
   <span class="hidden">
        SQL_Save:   RefTableSAVE
        SQL_Get:    RefTableGET 
        SQL_Search: RefTableSearch
    </span>
<div class="">
  
        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg-10">
                    <h3 class="card-label container">Ref Table</h3>
                </div>
                <div class="card-toolbar">
                    
                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(5,0);" Text=" Add Ref Table" />
                </div>

            </div>
            <br />
            <div>
                <div class="row col-lg-12"> 
                    <label class="col-lg-2 control-label">Module Name</label>
                    <div class=" col-lg-3">
                            <asp:DropDownList ID="ddlREFTYPE" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid ddlREFTYPE">
                            <asp:ListItem Value="-1">Select All</asp:ListItem>                             
                           <asp:ListItem Value="Food">Food</asp:ListItem>
                        </asp:DropDownList> 
                    </div>

                    <label class="col-lg-2 control-label">Category Name</label>
                    <div class="col-lg-3">
                        <asp:DropDownList ID="ddlREFSUBTYPE" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid ddlREFSUBTYPE">
                            <asp:ListItem Value="-1">Select All</asp:ListItem>
                             <asp:ListItem Value="OpportunityLoss">Opportunity Loss</asp:ListItem>
                            <asp:ListItem Value="CampaignType">Campaign Type</asp:ListItem>
                            <asp:ListItem Value="Lead">Lead</asp:ListItem>    
                        </asp:DropDownList>
                     </div>
                    <div class=" col-lg-1">      
                        <input type="button" value="Search" class="btn btn-primary btn-sm" onclick="Bind();" title="Click here to search" />
                    </div>
                    </div>

                    


                </div>
                <!-- /.card-body -->

                <!-- /.card-footer-->
        </div>
        <!-- /.card -->
        <div class="card-body">
            <%-- Contain Load  Here --%>
            <div id="dvGrid" style="zoom: 0.9"></div>

        </div>

    </div>
</section>

