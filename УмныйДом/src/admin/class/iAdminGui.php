<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 20.04.2016
 * Time: 23:20
 */

namespace Smart\Server;


interface iAdminGui
{
    function Show();

    function GetUsers();

    function GetUser();
}