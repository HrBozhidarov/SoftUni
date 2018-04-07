<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
    if (isset($_GET['num'])) {
        $arr = array();
        $num = intval($_GET['num']);

        function isPrime($num) {
            $isPrime=true;
            for ($i = 2; $i <=$num/2; $i += 1) {
                if ($num%$i==0 && $num!=2){
                    return false;
                }
            }

            return $isPrime;
        }

        for ($i = 2; $i <=$num; $i += 1) {
           if (isPrime($i)){
               $arr[]=$i;
           }
        }

        echo implode(" ", array_reverse($arr));
    }
    ?>
</body>
</html>