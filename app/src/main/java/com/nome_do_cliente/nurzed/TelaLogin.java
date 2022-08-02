package com.nome_do_cliente.nurzed;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class TelaLogin extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_login);

        Button btlogar = findViewById(R.id.button2);

        btlogar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent it =  new Intent(TelaLogin.this, TelaHome.class);
            }
        });
    }
}