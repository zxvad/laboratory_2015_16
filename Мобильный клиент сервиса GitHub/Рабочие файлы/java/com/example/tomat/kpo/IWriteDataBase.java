package com.example.tomat.kpo;

/**
 * Created by Tomat on 21.04.2016.
 */
public interface IWriteDataBase {
    void saveRepository(Repository repository);
    void cloneRepository(Repository repository);
    void addToLikedRepository(Repository repository);
}
