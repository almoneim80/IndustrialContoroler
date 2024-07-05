/**
 *  Pages Authentication
 */

'use strict';
const formAuthentication = document.querySelector('#formAuthentication');

document.addEventListener('DOMContentLoaded', function (e) {
  (function () {
    // Form validation for Add new record
    if (formAuthentication) {
      const fv = FormValidation.formValidation(formAuthentication, {
        fields: {
          wathegano: {
            validators: {
              notEmpty: {
                message: 'الرجاء إدخال رقم الوثيقة'
              },
            }
          },
          username: {
            validators: {
              notEmpty: {
                message: 'الرجاء إدخال اسم المستخدم'
              },
              stringLength: {
                min: 6,
                message: 'اسم المستخدم يجب ان يكون اكثر من 6 احرف'
              }
            }
          },
          email: {
            validators: {
              notEmpty: {
                message: 'الرجاء إدخال البريد الإلكتروني'
              },
              emailAddress: {
                message: 'الرجاء إدخال عنوان بريد إلكتروني صحيح'
              }
            }
          },
          a: {
            validators: {
              notEmpty: {
                message: 'الرجاء إدخال نوع الحساب '
              },
            }
          },
          'email-username': {
            validators: {
              notEmpty: {
                message: 'الرجاء إدخال اسم المستخدم/ البريد الإلكتروني'
              },
              stringLength: {
                min: 6,
                message: 'اسم المستخدم يجب ان يكون اكثر من 6 احرف'
              }
            }
          },
          password: {
            validators: {
              notEmpty: {
                message: 'الرجاء إدخال كلمة السر '
              },
              stringLength: {
                min: 6,
                message: 'كلمة السر يجب ان تكون اكثر من 6 احرف'
              }
            }
          },
          'confirm-password': {
            validators: {
              notEmpty: {
                message: 'الرجاء تأكيد كلمة السر'
              },
              identical: {
                compare: function () {
                  return formAuthentication.querySelector('[name="password"]').value;
                },
                  message: 'كلمة السر التي تم تأكيدها ليست مطابقة لكلمة السر الجديدة'
              },
              stringLength: {
                min: 6,
                message: 'كلمة السر يجب ان تكون اكثر من 6 احرف'
              }
            }
          },
          terms: {
            validators: {
              notEmpty: {
                message: 'الرجاء الموافقة على الشروط'
              }
            }
          }
        },
        plugins: {
          trigger: new FormValidation.plugins.Trigger(),
          bootstrap5: new FormValidation.plugins.Bootstrap5({
            eleValidClass: '',
            rowSelector: '.mb-3'
          }),
          submitButton: new FormValidation.plugins.SubmitButton(),

          defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
          autoFocus: new FormValidation.plugins.AutoFocus()
        },
        init: instance => {
          instance.on('plugins.message.placed', function (e) {
            if (e.element.parentElement.classList.contains('input-group')) {
              e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
            }
          });
        }
      });
    }

    //  Two Steps Verification
    const numeralMask = document.querySelectorAll('.numeral-mask');

    // Verification masking
    if (numeralMask.length) {
      numeralMask.forEach(e => {
        new Cleave(e, {
          numeral: true
        });
      });
    }
  })();
});
