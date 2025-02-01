<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admindelete.aspx.cs" Inherits="JAM.admindelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <script type="text/javascript">
            $(document).ready(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
        </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
    <div class="card">
        <div class="card-body">
            <div class="row">
                 <div class="col">
                    <center>
                    <h1>Delete QP</h1>
                    </center>
                   </div>
            </div>
             <div class="row">
                    <div class="col">
                          <hr>
                    </div>
               </div>   
                <div class="row">
                    
                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" >
                            <Columns>     
                                <asp:BoundField DataField="SI_No" HeaderText=" SI_No " />
                                <asp:BoundField DataField="Code" HeaderText=" Course Code " />
                                 <asp:BoundField DataField="Scheme" HeaderText=" Scheme " />
                                 <asp:BoundField DataField="EMonth" HeaderText=" Exam Month " />
                                 <asp:BoundField DataField="EYear" HeaderText=" Exam Year " />
                                  <asp:BoundField DataField="CreatedAt" HeaderText=" Created At " />
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Eval("SI_No") %>' ></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                            </Columns>
                        </asp:GridView>
                </div>
       </div>
    </div>
</div>





</asp:Content>
