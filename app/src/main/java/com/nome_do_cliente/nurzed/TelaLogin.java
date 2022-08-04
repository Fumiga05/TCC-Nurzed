package com.nome_do_cliente.nurzed;

import androidx.appcompat.app.AppCompatActivity;
import androidx.navigation.NavController;
import androidx.navigation.fragment.NavHostFragment;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.nome_do_cliente.nurzed.ui.home.HomeFragment;
import com.nome_do_cliente.nurzed.ui.home.HomeViewModel;

public class TelaLogin extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_login);

        Button btlogar = findViewById(R.id.button2);

        btlogar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                NavHostFragment navHostFragment =
                        (NavHostFragment) getSupportFragmentManager().findFragmentById(R.id.nav_host_fragment_container);


                navHostFragment.onCreate(new HomeFragment().onCreateView(new HomeViewModel()));


            }
        });
    }
}