<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        table * {
            border: 1px solid black;
            width: 50px;
            height: 50px;
        }
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
    <?php
    $red=51;
    $blue=51;
    $green=51;

    for ($i = 0; $i < 5; $i++) {
        echo "<tr>";
        for ($j = 0; $j < 3; $j++) {
           if ($j==0){
               echo "<td style='background-color: rgb($red,0,0)'>";
               $red+=51;
           }
           else if($j==1){
               echo "<td style='background-color: rgb(0,$green,0)'>";
               $green+=51;
           }
           else {
               echo "<td style='background-color: rgb(0,0,$blue)'>";
               $blue+=51;
           }

           echo "</td>";
        }

        echo "</tr>";
    }
    ?>
</table>
</body>
</html>