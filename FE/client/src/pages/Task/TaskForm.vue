<template>
  <form v-on:submit.prevent="submitForm">
    <md-card>
      <md-card-header data-background-color="green">
        <h4 class="title">Tạo công việc </h4>
        <p class="category">Nhập thông tin công việc</p>
      </md-card-header>

      <md-card-content>
        <div class="md-layout">
          <div class="md-layout-item md-small-size-100 md-size-20">
            <div class="md-layout-item">
              <md-field>
                <label for="font">Dự án</label>
                <md-select v-model="form.projectId">
                  <md-option v-for="item in listproject.data" v-bind:key="item.id" :value="item.id">
                    {{ item.code }}
                  </md-option>
                </md-select>
              </md-field>
            </div>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-80">
            <md-field>
              <label>Tên công việc</label>
              <md-input v-model="form.name"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Code</label>
              <md-input v-model="form.code" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label for="status">Trạng thái</label>
              <md-select v-model="form.status" name="status" id="status">
                <md-option value="0">Active</md-option>
                <md-option value="1">InActive</md-option>
              </md-select>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Mô tả</label>
              <md-textarea v-model="form.description" type="text"></md-textarea>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-40">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày bắt đầu</p>
              <md-input id="startDate" v-model="form.startDate" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-40">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày kết thúc</p>
              <md-input id="endDate" v-model="form.endDate" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-20">
            <md-field>
              <label for="userId">Người nhận</label>
              <md-select v-model="form.userId">
                  <md-option v-for="user in listuser.data" v-bind:key="user.id" :value="user.id">
                    {{ user.name }}
                  </md-option>
                </md-select>
            </md-field>
          </div>
          <!-- <div class="md-layout-item md-small-size-100 md-size-80" style="margin-top: 40px">
            <label>Đã bàn giao <md-input v-model="firstname" type="checkbox"></md-input></label>
          </div> -->
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
        endDate: null,
        isAssigned: true,
        userId: 0,
        projectId: 0
      },

      listproject: [],
      listuser: []
    };
  },

  // Gửi request lên server khi mà postPost() được gọi
  created() {
    axios.get(`http://localhost:8080/project/getall`)
      .then(response => {
        this.listproject = response.data;
        console.log(this.listproject);
      })
      .catch(e => {
        console.log("error");
      });

    axios.get(`http://localhost:8080/user/getall`)
      .then(response => {
        this.listuser = response.data;
        console.log(this.listuser);
      })
      .catch(e => {
        console.log("error");
      });
  },

  methods: {
    submitForm() {
      axios.post('http://localhost:8080/task/create', this.form)
        .then((res) => {
          console.log(res);
          if (res.status == 200) {
            location.href = "http://localhost:8080/#/listproject";
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
  }
};
</script>
