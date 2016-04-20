package com.akhmerova.elvira.greenhouse.view.fragments;

import android.app.Fragment;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.akhmerova.elvira.greenhouse.R;

/**
 * Created by Elvira on 20.04.2016.
 */
public class StateFragment extends Fragment {
    public static StateFragment newInstance() {

        Bundle args = new Bundle();

        StateFragment fragment = new StateFragment();
        fragment.setArguments(args);
        return fragment;
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_state, container, false);

        return view;
    }
}
