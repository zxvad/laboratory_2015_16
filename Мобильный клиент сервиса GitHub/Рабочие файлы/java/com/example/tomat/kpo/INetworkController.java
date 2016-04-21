package com.example.tomat.kpo;

/**
 * Created by Tomat on 21.04.2016.
 */
public interface INetworkController {
    IRegistration registration(User user);
    IDownload  downloadRepository(int idRepository);
    IAuthorization authorization(User user);

}
