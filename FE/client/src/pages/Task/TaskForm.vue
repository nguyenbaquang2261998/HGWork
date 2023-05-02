<template>
  <form v-on:submit.prevent="submitForm">
    <md-card>
      <md-card-header data-background-color="green">
        <h4 v-if="form.id == 0" class="title">Tạo công việc </h4>
        <h4 v-if="form.id > 0" class="title">Cập nhật công việc </h4>
        <p class="category">Nhập thông tin công việc</p>
      </md-card-header>

      <md-card-content>
        <div class="md-layout">
          <div class="md-layout-item md-small-size-100 md-size-20">
            <div class="md-layout-item">
              <md-field>
                <label for="font">Dự án</label>
                <md-select required v-model="form.projectId">
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
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.name"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Code</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.code" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label for="status">Trạng thái</label>
              <md-select v-model="form.status" name="status" id="status">
                <md-option value="0">Backlog</md-option>
                <md-option value="1">Doing</md-option>
                <md-option value="2">Done</md-option>
                <md-option value="3">Pending</md-option>
                <md-option value="4">Canceled</md-option>
              </md-select>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Mô tả</label>
              <md-textarea required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" v-model="form.description" type="text"></md-textarea>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-40">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày bắt đầu</p>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" id="startDate" v-model="form.startDate" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-40">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày kết thúc</p>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" id="endDate" v-model="form.endDate" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-20">
            <md-field>
              <label for="userId">Người nhận</label>
              <md-select required v-model="form.userId">
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
            <md-button v-if="form.id == 0" type="submit" class="md-raised md-success">Tạo công việc</md-button>
            <md-button v-if="form.id > 0" type="submit" class="md-raised md-success">Cập nhật công việc</md-button>
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
        id: 0,
        name: '',
        code: '',
        status: 0,
        description: '',
        startDate: new Date(),
        endDate: new Date(),
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

    // get data task if update
    const param = this.$route.params.id;
    if (typeof(param) != "undefined") {
      axios.get(`http://localhost:8080/task/detail/` + param)
        .then(response => {
          this.form.id = response.data.data.id;
          this.form.name = response.data.data.name;
          this.form.code = response.data.data.code;
          this.form.status = response.data.data.status;
          this.form.description = response.data.data.description;
          this.form.startDate = this.formatDate(response.data.data.startDate);
          this.form.endDate = this.formatDate(response.data.data.endDate);
          this.form.isAssigned = response.data.data.isAssigned;
          this.form.projectId = response.data.data.projectId;
          this.form.userId = response.data.data.userId;
        })
        .catch(e => {
          console.log("error");
        })
    }
  },

  methods: {
    submitForm() {
      if(this.form.id > 0){
        axios.post('http://localhost:8080/task/update', this.form)
        .then((res) => {
          if (res.status == 200) {
            location.href = "http://localhost:8080/#/listtasks/0";
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
      else{
        axios.post('http://localhost:8080/task/create', this.form)
        .then((res) => {
          if (res.status == 200) {
            location.href = "http://localhost:8080/#/listtasks/0";
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
    formatDate(input) {
      var datePart = input.match(/\d+/g),
        year = datePart[0], // get only two digits
        month = datePart[1], day = datePart[2];

      return year + '-' + month + '-' + day;
    }
  }
};
</script>
