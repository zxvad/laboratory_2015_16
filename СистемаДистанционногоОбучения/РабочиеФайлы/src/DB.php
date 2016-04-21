<?php
namespace Diplom;
class DB implements iDB
{
    protected $mysqli;
    function Connect($param)
    {
        $param = func_get_args();
        $this->mysqli = new mysqli($param['host'], $param['user'], $param['pass'], $param['world']);
        if ($this->mysqli->connect_errno) {
            printf("Не удалось подключиться: %s\n", $this->mysqli->connect_error);
            exit();
        }
    }
    function Query($query, $row = null)
    {
        $res = $this->mysqli->query($query);
        return $row === null ? $res : mysqli_fetch_array($res);
    }
    function Die(\Exception $e)
    {
        die($e->getMessage() . ' at line: ' . $e->getLine());
    }
}