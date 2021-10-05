<%@ Page Title="City Entry" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="CityState.aspx.cs" Inherits="CourierNew.Pages.CityState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CP1" runat="server">
    <asp:Label runat="server" ID="ltMsg"></asp:Label>
      <span class="hidden">
        SQL_Save:   CityStatesCountySAVE
        SQL_Get:    CityStatesCountyGET 
        SQL_Search: CityStatesCountySEARCH

    </span>
    <!------------------Step 1 Set Page Size----->
    <script src="Js/CityStatEntry.js"> </script>
   
    <script>

        var iframe = window.parent.document.getElementById("frameShortcut");
        if (iframe != null) {
            window.parent.$(".homeframetitle").html('City Entry');
            // Adjusting the iframe height onload event
            iframe.onload = function () {

                iframe.style.height = '500px';
            }

         //   window.parent.$("#MainModel").addClass('modal-xl');
        }
   
    </script>
     <div class="add-btn btntop  fixed-top p-1 text-right">
        <TopButton:Buttons runat="server" ID="btnTop" VisibleSave="true" VisibleCancel="true" OnMasterEve="Buttons_MasterEve" enRole="CityState"  />
    </div>
     <!------------------Step 2 Page Design------->
    <section class="content" style="margin-top:50px">
        <div class="container-fluid">
            
                <div class ="col-lg-2">
                <div class="form-group">
                    <label>Country</label>
                    <asp:DropDownList ID="ddlCOUNTRYID" runat="server"  AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCOUNTRYID_SelectedIndexChanged" CssClass="form-control form-control-solid form-control-lg  ddlCOUNTRYID">
                        <asp:ListItem Value="-1">Select Country</asp:ListItem>
                    </asp:DropDownList>
                </div> 
                <div class="form-group">
                    <label>State</label>
                    <asp:DropDownList ID="ddlStateID" runat="server"  AppendDataBoundItems="true" CssClass="form-control form-control-solid form-control-lg  ddlStateID">
                        <asp:ListItem Value="-1">Select State</asp:ListItem>
                    </asp:DropDownList>
                </div>  
                </div>
                <div class="col-lg-2">
                <div class="form-group">
                    <label >City English</label>
                    <asp:TextBox runat="server"  placeholder="Name English" ID="txtCityEnglish" class="form-control form-control-solid form-control-lg  txtCityEnglish"></asp:TextBox>
                </div>                
                <div class="form-group">
                    <label >City Arabic</label>
                    <asp:TextBox runat="server"  placeholder="Name Arabic" ID="txtCityArabic" class="form-control form-control-solid form-control-lg  txtCityArabic"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label >City Other</label>
                    <asp:TextBox runat="server"  placeholder="Name Other" ID="txtCityOther" class="form-control form-control-solid form-control-lg  txtCityOther"></asp:TextBox>
                </div>
                </div>
        
          </div>
       
    </section>
</asp:Content>
