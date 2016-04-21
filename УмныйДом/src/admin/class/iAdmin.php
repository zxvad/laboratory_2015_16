<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 20.04.2016
 * Time: 23:14
 */

namespace Smart\Server;


interface iAdmin
{
    function ShowAuth();

    function ShowGui();

    function InitDB($param);

    function ShowUsers();
}