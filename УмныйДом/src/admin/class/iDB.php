<?php
/**
 * Created by PhpStorm.
 * User: Stiznich
 * Date: 20.04.2016
 * Time: 23:34
 */

namespace Smart\Server;


interface iDB
{
    function Connect($param);

    function Query($query);

    function Die(\Exception $e);
}