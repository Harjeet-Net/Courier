<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrCityState.ascx.cs" Inherits="CourierNew.UserControl.CtrCityState" %>
<script src="../UserControl/Js/CityStateSearch.js"></script>
<section class="content">
     <span class="hidden">
        SQL_Save   :   CityStatesCountySAVE
        SQL_Get    :    CityStatesCountyGET 
        SQL_Search : CityStatesCountySEARCH

    </span>
    <!-- Default box -->
   <div class="">
  
        <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="HeadTitle"></h3>
                <div class="card-title col-lg-10">
                    <h3 class="card-label container">City Master</</h3>
                </div>
                <div class="card-toolbar">                   
                    <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(7,0);" Text=" Add City/State" />
                </div>

            </div> 
            <br />
              <div>
                <div class="row col-lg-12 container">
                    <label class="col-lg-2 control-label">Country</label>
                    <div class=" col-lg-3">                        
                        <asp:DropDownList ID="ddlCOUNTRYID" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid ddlCOUNTRYID">
                            <asp:ListItem Value="-1">Select All</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <label class="col-lg-2 control-label hidden">State</label>
                    <div class="col-lg-3 hidden">                      
                        <asp:DropDownList ID="ddlStateID" runat="server" AppendDataBoundItems="true" CssClass="form-control form-control-solid  ddlStateID">
                            <asp:ListItem Value="-1">Select All</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class=" col-lg-1">
                        <input type="button" value="Search" class="btn btn-primary btn-sm" onclick="Bind();" title="Click here to search" />
                    </div>


                </div>
                <!-- /.card-body -->

                <!-- /.card-footer-->
            </div>
        </div>
        <!-- /.card -->
        <div class="card-body">
            <%-- Contain Load  Here --%>
            <div id="dvGrid" style="zoom: 0.9"></div>

        </div>

    </div>
</section>

