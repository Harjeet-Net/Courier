<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrUserMaster.ascx.cs" Inherits="CourierNew.UserControl.CtrUserMaster" %>

<script src="../UserControl/Js/UserEntrySearch.js?ver=2"></script>

<section class="container">
    <span class="hidden">
        SQL_Save: UserMasterSAVE
        SQL_Get:  UserMasterGET
        SQL_Search:  UserMasterSEARCH
        SQL_Autheincate:  UserAutehnticate
    </span>
    <!-- Default box -->
    <!--begin::Card-->
    <div class="">
            <div class="border-bottom pt-6 row">
                <h3 class="card-title" runat="server" id="H1"></h3>
                <div class="card-title col-lg">
                    <h3 class="card-label">User Master</h3>
                </div>
                <div class="card-toolbar">
                    
                 <asp:Button runat="server" CssClass="btn btn-primary button-color btn-fixed-height font-weight-bold px-2 px-lg-5 mr-2" ID="btnCatAdd" OnClientClick="return Op(1,0);" Text=" Add User" />
                 </div>

            </div>
        </div>
        <!-- /.card -->
        <div class="card-body">
            <%-- Contain Load  Here --%>
            <div id="dvGrid" style="zoom: 0.9"></div>

        </div>
</section>

