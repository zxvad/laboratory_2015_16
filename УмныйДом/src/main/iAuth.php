<?
interface iAuth{
    public function Validation();
    public function getAuth();
    public function logOut();
    public function isAuth($username, DB $db = null);
}
?>