<?
interface iInterController{
    public function getDataByTime();
    public function getDataById($id);
    public function sendData(DB $db = null,$id,$value);
}
?>