package com.example.tomat.kpo;

import java.util.List;

/**
 * Created by Tomat on 21.04.2016.
 */
public interface IDownload {
    List<Repository > downloadRepository(int idRepository);
    List<Repository> searchRepositories(String keyWord);
 }
