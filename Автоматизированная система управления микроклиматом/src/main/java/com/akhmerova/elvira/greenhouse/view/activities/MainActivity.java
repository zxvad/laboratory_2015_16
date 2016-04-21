package com.akhmerova.elvira.greenhouse.view.activities;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;

import com.akhmerova.elvira.greenhouse.R;
import com.akhmerova.elvira.greenhouse.view.fragments.StateFragment;

import butterknife.Bind;
import butterknife.ButterKnife;

public class MainActivity extends AppCompatActivity {

    @Bind(R.id.current_btn)
    Button currentButton;
    @Bind(R.id.report_btn)
    Button reportButton;
    @Bind(R.id.settings_btn)
    Button settingsButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ButterKnife.bind(this);
        if (savedInstanceState == null) {
            getFragmentManager().beginTransaction()
                    .add(R.id.fragment_container, StateFragment.newInstance())
                    .commit();
            currentButton.setSelected(true);
        }
    }
}
