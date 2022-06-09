<?php
include "conexion.inc.php";
$flujo = $_GET["codFlujo"];
$proceso = $_GET["codProceso"];
$sql = "SELECT * FROM proceso WHERE codFlujo='$flujo' AND codProceso = '$proceso'";
$resultado = mysqli_query($con, $sql);
$fila = mysqli_fetch_array($resultado);
$pantalla = $fila['pantalla'];
$pantalla.=".inc.php";

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Principal</title>
</head>
<body>

    <h1>Contenido</h1>
    <?php 
        include $pantalla;

    ?>
</body>
</html>