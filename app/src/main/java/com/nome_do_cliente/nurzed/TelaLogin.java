package com.nome_do_cliente.nurzed;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.nome_do_cliente.nurzed.databinding.ActivityTelaHomeBinding;
import com.nome_do_cliente.nurzed.ui.dashboard.DashboardFragment;
import com.nome_do_cliente.nurzed.ui.home.HomeFragment;
import com.nome_do_cliente.nurzed.ui.notifications.NotificationsFragment;

public class TelaLogin extends AppCompatActivity {

    private ActivityTelaHomeBinding binding;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_login);
        EditText edtcpf = findViewById(R.id.edCpf);
        Button btlogar = findViewById(R.id.btlogin);
        EditText edtsenha = findViewById(R.id.edtxtSenha);
        String senha ="j" ;
        String cpf = null;

        if (edtcpf.equals(cpf) && edtsenha.equals(senha) ) {
            btlogar.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    binding = ActivityTelaHomeBinding.inflate(getLayoutInflater());
                    setContentView(binding.getRoot());
                    replacefragment(new HomeFragment());

                    binding.bottomNavigationView.setOnItemSelectedListener(item -> {


                        switch (item.getItemId()) {
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


                        return true;
                    });
                }


                private void replacefragment(Fragment fragment) {

                    FragmentManager fragmentManager = getSupportFragmentManager();
                    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                    fragmentTransaction.replace(R.id.frame_layout, fragment);
                    fragmentTransaction.commit();

                }


            });
        }
    }
}