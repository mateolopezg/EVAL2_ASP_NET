<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumidorRut.aspx.cs" Inherits="EVAL_2.ConsumidorRut" %>

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
            <a class="nav-link" href="ConsumirVuelos.aspx">Buscar Vuelos</a>
            <a class="nav-link" href="#">Buscar Pasajero</a>
          </div>
        </div>
      </div>
    </nav>     
    
    <div class="card">
        <form id="form1" runat="server">
            <div class="card-header">
                <h5 class="card-title">Ingrese el Rut o ID del pasajero a Buscar</h5>
                <h6 class="card-subtitle mb-2 text-muted">Recuerde que solo tendrá resultados si el ID o RUT es valido</h6>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click"/>
                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" Height="231px" style="margin-top: 23px" Width="272px" CellSpacing="2">
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
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
