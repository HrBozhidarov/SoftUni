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
        $arr = array(1,1,2);
        $num = intval($_GET['num']);
        $firstNumber=1;
        $secondNumber=1;
        $thirthNumber=2;

        for ($i = 0; $i <$num-3; $i += 1) {
            $temp=$firstNumber + $secondNumber + $thirthNumber;
            $firstNumber=$secondNumber;
            $secondNumber=$thirthNumber;
            $thirthNumber = $temp;
            $arr[]=$thirthNumber;
        }

        echo implode(" ", $arr);
    }
    ?>
</body>
</html>