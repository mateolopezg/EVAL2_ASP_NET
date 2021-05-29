<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumirVuelos.aspx.cs" Inherits="EVAL_2.ConsumirVuelos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <style>
      body{
          
          background-color: #222;
          border-color: #080808;
      }
      .img-A{
        padding-right: 1000px;
        padding-bottom: 10px;
      }
    </style>

</head>
<body>   
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Buscardor de Volar y Disfrutar</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
          <div class="navbar-nav">
            <a class="nav-link active" aria-current="page" href="http://localhost:49843/">Home</a>
            <a class="nav-link" href="http://localhost:49843/Pasaje">Mostrar Vuelos</a>
            <a class="nav-link" href="http://localhost:49843/MantenimientoPasajes">Mantenedor Vuelos</a>
            <a class="nav-link" href="http://localhost:49843/MantenedorPasajeros">Mantenedor Pasajeros</a>
            <a class="nav-link" href="#">Buscar Vuelos</a>
            <a class="nav-link" href="ConsumidorRut.aspx">Buscar Pasajero</a>
          </div>
        </div>
      </div>
    </nav>     
    
    <div class="card">
        <form id="form1" runat="server">
            <div class="card-header">
                <h5 class="card-title">Ingrese el ID del vuelo</h5>
                <h6 class="card-subtitle mb-2 text-muted">Recuerde que solo tendrá resultados si el ID es valido</h6>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-primary"  OnClick="btnBuscar_Click"/>
                <asp:TextBox ID="txtId" runat="server" OnTextChanged="txtId_TextChanged"></asp:TextBox>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="231px" style="margin-top: 23px" Width="272px">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
        </form>
        <img src="data:image/jpeg;base64,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" 
            class="rounded mx-auto d-block img-A" alt="">
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
    
    <div class="container body-content">
        <hr />
        <footer>
            <p>&copy; 2021 - La mejor forma de volar</p>
        </footer>
    </div>
</body>
</html>
