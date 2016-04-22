package com.example.griz.attendance;

import java.util.Date;
import java.util.List;

public class ListModel {

    private Date date;
    private String Subject;
    private List<String> attendList;

    public ListModel(){

    }
    public ListModel(Date date,String Subject,List<String> listOfStudents){
        this.attendList=listOfStudents;
        this.date=date;
        this.Subject=Subject;
    }
    public void setDate(Date date){
        this.date=date;
    }
    public Date getDate(){
        return this.date;
    }
    public void setSubject(String subject){
        this.Subject=subject;
    }
    public String getSubject(){
        return this.Subject;
    }
    public void setAttendList(List<String> attendList){
        this.attendList=attendList;
    }
    public List<String> getAttendList(){
        return this.attendList;
    }
}
