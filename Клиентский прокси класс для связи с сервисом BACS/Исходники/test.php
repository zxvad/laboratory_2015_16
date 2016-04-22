<?php

include 'Client.php';
$apiClient = new Bacs\Client();

$submit = new Bacs\model\Submit('D','LOL',1);
$all[] = $submit;
$all[] = new Bacs\model\Submit('D','tot',2);

try{
    echo '<pre>';
    $res = $apiClient->getResultAll(array(4051,4052));
    var_dump($res);
    echo '</pre>';
}catch(Exception $e){
    echo $e->getMessage();
}

