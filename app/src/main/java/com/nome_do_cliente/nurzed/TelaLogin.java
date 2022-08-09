package com.nome_do_cliente.nurzed;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.navigation.NavController;
import androidx.navigation.fragment.NavHostFragment;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.nome_do_cliente.nurzed.databinding.ActivityTelaHomeBinding;
import com.nome_do_cliente.nurzed.ui.dashboard.DashboardFragment;
import com.nome_do_cliente.nurzed.ui.home.HomeFragment;
import com.nome_do_cliente.nurzed.ui.home.HomeViewModel;
import com.nome_do_cliente.nurzed.ui.notifications.NotificationsFragment;

public class TelaLogin extends AppCompatActivity {

    private ActivityTelaHomeBinding binding;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_login);

        Button btlogar = findViewById(R.id.button2);

        btlogar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                binding = ActivityTelaHomeBinding.inflate(getLayoutInflater());
                setContentView(binding.getRoot());
                replacefragment(new HomeFragment());

                binding.bottomNavigationView.setOnItemSelectedListener(item -> {


                    switch (item.getItemId()){
                        case R.id.home:
                            replacefragment(new HomeFragment());
                            break;
                        case R.id.perfil:
                            replacefragment(new DashboardFragment());
                            break;
                        case R.id.notific:
                            replacefragment(new NotificationsFragment());
                            break;

                    }



                    return  true;
                });
            }

            private void  replacefragment (Fragment fragment){

                FragmentManager fragmentManager = getSupportFragmentManager();
                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                fragmentTransaction.replace(R.id.frame_layout,fragment);
                fragmentTransaction.commit();

            }


            
        });
    }
}