<template>
  <form v-on:submit.prevent="submitForm">
    <md-card>
      <md-card-header data-background-color="green">
        <h4 class="title">Tạo tài khoản </h4>
        <p class="category">Nhập thông tin tài khoản</p>
      </md-card-header>

      <md-card-content>
        <div class="md-layout">
          <div class="md-layout-item md-small-size-100 md-size-33">
            <md-field>
              <label>Tên người dùng</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.name"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-33">
            <md-field>
              <label>Email</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.email" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-33">
            <md-field>
              <label>Số điện thoại</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.phone" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Tài khoản</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.userName" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-25">
            <md-field>
              <label>Mật khẩu</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.password" type="password"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-25">
            <md-field>
              <label>Nhập lại mật khẩu</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.repassword" type="password"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label for="status">Trạng thái</label>
              <md-select required v-model="form.status" name="status" id="status">
                <md-option value="0">Active</md-option>
                <md-option value="1">Lock</md-option>
              </md-select>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-checkbox v-model="form.isAdmin">Quyền Admin</md-checkbox>
          </div>
          <!-- <div class="md-layout-item md-small-size-100 md-size-80" style="margin-top: 40px">
            <label>Đã bàn giao <md-input v-model="firstname" type="checkbox"></md-input></label>
          </div> -->
          <div class="md-layout-item md-size-100 text-right">
            <md-button type="submit" class="md-raised md-success">Tạo tài khoản</md-button>
          </div>
        </div>
      </md-card-content>
    </md-card>
  </form>
</template>
<script>
import axios from 'axios';
export default {
  name: "edit-profile-form",
  props: {
    dataBackgroundColor: {
      type: String,
      default: "",
    },
  },
  data() {
    return {
      form: {
        name: '',
        phone: '',
        email: '',
        userName: '',
        password: '',
        repassword: '',
        status: 0,
        isAdmin: false
      },

      listuser: []
    };
  },

  // Gửi request lên server khi mà postPost() được gọi
  methods: {
    submitForm() {
      if (this.form.password != this.form.repassword) {
        alert('Nhập lại mật khẩu không chính xác');
      }
      else{
        axios.post('http://localhost:8080/user/create', this.form)
        .then((res) => {
          console.log(res);
          if (res.status == 200) {
            location.href = "http://localhost:8080/#/listuser";
          }
          else {
            alert('Đã có lỗi xảy ra!');
          }
        })
        .catch((error) => {
          alert('Đã có lỗi xảy ra!');
        }).finally(() => {
          //Perform action in always
        });
      }
    },
  }
};
</script>
