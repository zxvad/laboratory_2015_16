<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 20.04.2016
 * Time: 23:31
 */

namespace Smart\Server;


interface iUsersGui
{
    function GetUsersList();

    function SearchUser($param);
}