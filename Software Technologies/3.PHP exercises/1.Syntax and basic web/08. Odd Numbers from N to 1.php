<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num"/>
    <input type="submit"/>
</form>
<?php
if (isset($_GET['num'])) {
    $arr = array();
    $num = intval($_GET['num']);

    for ($i = $num; $i >= 1; $i -= 1) {
        if ($i % 2 == 1) {
            $arr[] = $i;
        }
    }
}
echo implode(" ", $arr);
?>
</body>
</html>