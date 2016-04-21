<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 21.04.2016
 * Time: 1:25
 */

namespace Smart\Server;


class User implements iUser
{
    protected $id, $modules, $time, $notes;
    function SendNote(){}

    function AddModule($module){}

    function DeleteModule($module){}

}