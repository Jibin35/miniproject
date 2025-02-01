<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="JAM.downloading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">
  $(document).ready(function () {
      $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
  });
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
    <div class="card">
        <div class="card-body">
            <div class="row">
                 <div class="col">
                    <center>
                    <h1>Download QP</h1>
                    </center>
                   </div>
            </div>
             <div class="row">
                    <div class="col">
                          <hr>
                    </div>
               </div>   
                <div class="row">
                    <asp:GridView class="table table-striped table-bordered"   ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>                               
                                <asp:BoundField DataField="Code" HeaderText=" Course Code " />
                                 <asp:BoundField DataField="Scheme" HeaderText=" Scheme " />
                                 <asp:BoundField DataField="EMonth" HeaderText=" Exam Month " />
                                 <asp:BoundField DataField="EYear" HeaderText=" Exam Year " />
                                <asp:TemplateField HeaderText="Download">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click" CommandArgument='<%# Eval("FilePath") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                </div>
       </div>
    </div>
</div>
</asp:Content>
