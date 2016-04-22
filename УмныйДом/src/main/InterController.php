<?
require_once "iInterController.php";
require_once "DB.php";
class InterController implements iInterController
{
    private $id;
    private $value;
    private $interval;
    private $db;
    private function __construct($interval){
        $this->intetrval = $interval;
    }
    public function sendData(DB $db = null,$id,$value)
    {
        if($db == null){
            $this->db = new DB("1","2","3","4");
        }else{
            $this->db = $db;
        }
    }

    public function getDataByTime()
    {

    }
    public function getDataById($id)
    {

    }
}

?>