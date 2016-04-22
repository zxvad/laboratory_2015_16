<?
require_once "iHandler.php";
require_once "Auth.php";
require_once "DB.php";
require_once "InterController.php";
class Handler implements iHandler
{
    private $auth;
    private $db;
    private $interController;
    public function makeAuth(Auth $auth = null){
        if($auth!=null){
            $auth->getAuth();
        }else{
            $this->auth = new Auth("1","2");
        }
    }
    public function makeInterController(){
        $this->interController = new InterController();
    }
    public function makeDB(DB $db = null){
        if ($db == null){
            $this->db = new DB("1","2","3","4");
        }
      $this->db = $db;
    }
}
?>