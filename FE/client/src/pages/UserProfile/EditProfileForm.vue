<template>
  <form v-on:submit.prevent="submitForm">
    <md-card>
      <md-card-header :data-background-color="dataBackgroundColor">
        <h4 class="title">Tạo dự án</h4>
        <p class="category">Nhập thông tin dự án</p>
      </md-card-header>

      <md-card-content>
        <div class="md-layout">
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Tên dự án</label>
              <md-input id="name" v-model="form.name"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Code</label>
              <md-input id="code" v-model="form.code" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Trạng thái</label>
              <md-input id="status" v-model="form.status" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Mô tả</label>
              <md-input id="description" v-model="form.description" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày bắt đầu</p>
              <md-input id="startDate" v-model="form.startDate" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày kết thúc</p>
              <md-input id="endDate" v-model="form.endDate" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-size-100 text-right">
            <md-button type="submit" class="md-raised md-success">Tạo dự án</md-button>
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
        code: '',
        status: 0,
        description: '',
        startDate: null,
        endDate: null
      }
    }
  },
  // Gửi request lên server khi mà postPost() được gọi
  methods: {
    submitForm() {
      axios.post('http://localhost:8080/project/create', this.form)
        .then((res) => {
          console.log(res);
          if(res.status == 200)
          {
            location.href = "http://localhost:8080/#/listproject";
          }
          else{
            alert('Đã có lỗi xảy ra!');
          }
        })
        .catch((error) => {
          alert('Đã có lỗi xảy ra!');
        }).finally(() => {
          //Perform action in always
        });
    }
  }
};
</script>
<style></style>
