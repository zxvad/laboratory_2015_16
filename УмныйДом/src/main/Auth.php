<?
require_once "DB.php";
require_once "iAuth.php";
class Auth implements iAuth
{
    private $username;
    private $pass;
    private $db;
    public function __construct($username,$pass){
        $this->username  = $username;
        $this->pass = $pass;
    }
    public function Validation(){

    }
    public function getAuth(){

    }
    public function logOut(){

    }
    public function isAuth($username, DB $db = null){
        if($db == null){
            $this->db = new DB("1","2","3","4");
        }else{
            $this->db = $db;
        }
    }
}
?>