<?
interface iHandler{
    public function makeAuth(Auth $auth = null);
    public function makeDB(DB $db = null);
    public function makeInterController();
}
?>