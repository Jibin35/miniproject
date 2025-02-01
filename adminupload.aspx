<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminupload.aspx.cs" Inherits="JAM.adminupload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
   $(document).ready(function () {
       $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
   });
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
         <div class="row">
             <div class="col-md-5">
                 <div class="card">
                     <div class="card-body">
                         <div class="row">
                             <div class="col">
                                <center>
                                   <h4>Upload</h4>
                                </center>
                             </div>
                          </div>
                          
                          <div class="row">
                             <div class="col">
                                <center>
                                   <img width="100px" src="imgs/upload.png" />
                                </center>
                             </div>
                          </div>
                         <div class="row">
                           <div class="col">
                              <hr>
                           </div>
                        </div>
                         <div class="row">
                             <div class="col">
                                <asp:FileUpload class="form-control" ID="fileUpload" runat="server" />
                             </div>
                        </div>
                         <br />
                          <div class="row">
                            <div class="col-md-6">
                               <label>Subject Code</label>
                                
                               <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Eg:CST301"></asp:TextBox>
                               </div>
                            </div>
                              
                            <div class="col-md-6">
                               <label>Scheme</label>
                               <div class="form-group">
                                   <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                      <asp:ListItem Text="2019" Value="2019" />
                                      <asp:ListItem Text="2015" Value="2015" />
                                 </asp:DropDownList>
                               </div>
                            </div>
                         </div>
                         <br />

                         <div class="row">
                             <div class="col-md-6">
                               <label>Exam Month</label>
                               <div class="form-group">
                                   <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                      <asp:ListItem Text="January" Value="January" />
                                      <asp:ListItem Text="February" Value="February" />
                                       <asp:ListItem Text="March" Value="March" />
                                       <asp:ListItem Text="April" Value="April" />
                                        <asp:ListItem Text="May" Value="May" />
                                         <asp:ListItem Text="June" Value="June" />
                                          <asp:ListItem Text="July" Value="July" />
                                          <asp:ListItem Text="August" Value="August" />
                                        <asp:ListItem Text="September" Value="September" />
                                         <asp:ListItem Text="October" Value="October" />
                                          <asp:ListItem Text="November" Value="November" />
                                          <asp:ListItem Text="December" Value="December" />
                                 </asp:DropDownList>
                               </div>
                            </div>
                             <div class="col-md-6">
                                 <label>Exam Year</label>
                                 <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Eg:2021"></asp:TextBox>
                             </div>
                         </div>
                          <br />
                           <div class="row">
                               <div class="col mx-auto">
                                  <center>
                                     <div class="form-group">
                                         <asp:Button class="btn btn-primary w-100" ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
                                     </div>
                                  </center>
                               </div>
                           </div>
                         <br />
                     </div>
                 </div>
             </div>


             <div class="col-md-7">
               <div class="card">
                  <div class="card-body">
                     <div class="row">
                        <div class="col">
                           <center>
                              <h4>QP List</h4>
                           </center>
                        </div>
                     </div>
                     <div class="row">
                        <div class="col">
                           <hr>
                        </div>
                     </div>
                     <div class="row">    
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:qplibraryConnectionString3 %>" ProviderName="<%$ ConnectionStrings:qplibraryConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [QP]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1" ></asp:GridView>
                        </div>
                     </div>
                  </div>
               </div>
            </div>


         </div>
    </div>


</asp:Content>
