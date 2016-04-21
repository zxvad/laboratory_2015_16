<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 20.04.2016
 * Time: 23:28
 */

namespace Smart\Server;


interface iAuth
{
    function CheckAuth();

    function MakeAuth();
}