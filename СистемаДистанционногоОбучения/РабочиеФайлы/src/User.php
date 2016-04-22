<?php
namespace Diplom;
class User extends Authorization implements iUser
{
 public $login,$permission;
    function GetPermission(DB $db)
    {
        $db->Connect(1,2,3,4);
    }
}