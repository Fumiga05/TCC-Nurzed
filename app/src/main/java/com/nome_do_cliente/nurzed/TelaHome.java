package com.nome_do_cliente.nurzed;

import android.os.Bundle;

import com.google.android.material.bottomnavigation.BottomNavigationView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import com.nome_do_cliente.nurzed.databinding.ActivityTelaHomeBinding;
import com.nome_do_cliente.nurzed.ui.dashboard.DashboardFragment;
import com.nome_do_cliente.nurzed.ui.home.HomeFragment;
import com.nome_do_cliente.nurzed.ui.notifications.NotificationsFragment;

public class TelaHome extends AppCompatActivity {

    private ActivityTelaHomeBinding bind;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        bind = ActivityTelaHomeBinding.inflate(getLayoutInflater());
        setContentView(bind.getRoot());
        replacefragment(new HomeFragment());

        bind.bottomNavigationView.setOnItemSelectedListener(item -> {


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

}