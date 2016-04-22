<?
require_once "iDB.php";
class DB implements iDB
{
    private $db;
    private $host;
    private $pass;
    private $usr;
    private $db_name;

    public function __construct($host, $usr, $pass, $db_name)
    {
        $this->host = $host;
        $this->usr = $usr;
        $this->pass = $pass;
        $this->db_name = $db_name;
        $this->connect();
    }

    public function connect()
    {
        $dsn = "mysql:host=" . $this->host . ";dbname=" . $this->db_name;
        try {
            $db = new PDO($dsn, $this->usr, $this->pass);
            $this->db = $db;
        } catch (PDOException $e) {
            echo 'Подключение не удалось: ' . $e->getMessage();
        }
    }

    public function authorization()
    {

    }


}

?>