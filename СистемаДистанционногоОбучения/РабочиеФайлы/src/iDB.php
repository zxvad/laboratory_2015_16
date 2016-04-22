<?php
namespace Diplom;
interface iDB
{
    function Connect($param);
    function Query($query);
    function Die(\Exception $e);
}