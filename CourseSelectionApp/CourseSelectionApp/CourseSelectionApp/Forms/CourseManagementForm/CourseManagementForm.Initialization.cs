using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CourseSelectionApp.Commons;
using CourseSelectionApp.Models.Dto;

namespace CourseSelectionApp.Forms
{
    partial class CourseManagementForm
    {
        /// <summary>
        /// 初始化使用者定義之元件
        /// </summary>
        /// <param name="controlCommons"></param>
        private void InitializeUserDefinedComponents(ControlCommons controlCommons)
        {
            controlCommons.SetDoubleBuffered(this, true);
            controlCommons.SetDoubleBuffered(_courseList, true);
            controlCommons.SetDoubleBuffered(_courseTimeGrid, true);

            _courseList.DisplayMember = nameof(CourseListItem.CourseName);
            _courseList.ValueMember = nameof(CourseListItem.CourseWithActivateAndClass);
            _classComboBox.DisplayMember = nameof(ClassListItem.ClassName);
            _classComboBox.ValueMember = nameof(ClassListItem.Class);

            var textPropertyName = nameof(Text);
            var enabledPropertyName = nameof(Enabled);
            var isCourseSelectedPropertyName = nameof(_courseManagementFormPresentationModel.IsCourseSelectedOrCreated);

            InitializeEnabledDataBindingsForNestedInputs(enabledPropertyName, isCourseSelectedPropertyName);
            InitializeDataBindingsForInputText(textPropertyName);
            InitializeDataBindingsForInputTextChangedEvent();
            InitializeOtherComponents(enabledPropertyName, textPropertyName);
        }

        /// <summary>
        /// 綁定其他元件的資料
        /// </summary>
        /// <param name="enabledPropertyName"></param>
        /// <param name="textPropertyName"></param>
        internal void InitializeOtherComponents(string enabledPropertyName, string textPropertyName)
        {
            // _newCourseButton
            _newCourseButton.Click += ListenNewCourseButtonOnClick;
            AddDataBinding(_newCourseButton, enabledPropertyName, nameof(_courseManagementFormPresentationModel.IsNewCourseButtonEnabled));
            // _createOrSaveCourseButton
            AddDataBinding(_createOrSaveCourseButton, enabledPropertyName, nameof(_courseManagementFormPresentationModel.IsCreateOrSaveButtonEnabled));
            AddDataBinding(_createOrSaveCourseButton, textPropertyName, nameof(_courseManagementFormPresentationModel.CreateOrSaveButtonText));
            _createOrSaveCourseButton.Click += ListenCreateOrSaveButtonOnClick;
            // _courseGroupBox
            AddDataBinding(_courseGroupBox, textPropertyName, nameof(_courseManagementFormPresentationModel.GroupBoxText));
        }

        /// <summary>
        /// 綁定所有輸入元件的 Enabled 狀態
        /// </summary>
        /// <param name="enabledPropertyName"></param>
        internal void InitializeEnabledDataBindingsForNestedInputs(string enabledPropertyName, string isCourseSelectedPropertyName)
        {
            AddDataBindingsForNestedInputs(_courseEditorLine1, enabledPropertyName, isCourseSelectedPropertyName);
            AddDataBindingsForNestedInputs(_courseEditorLine2, enabledPropertyName, isCourseSelectedPropertyName);
            AddDataBindingsForNestedInputs(_courseEditorLine3, enabledPropertyName, isCourseSelectedPropertyName);
            AddDataBindingsForNestedInputs(_courseEditorLine4, enabledPropertyName, isCourseSelectedPropertyName);
            AddDataBindingsForNestedInputs(_courseEditorLine5, enabledPropertyName, isCourseSelectedPropertyName);

            // _currentCourseTimeGrid
            AddDataBinding(_courseTimeGrid, enabledPropertyName, isCourseSelectedPropertyName);
        }

        /// <summary>
        /// 設定 Text Binding
        /// </summary>
        /// <param name="textPropertyName"></param>
        internal void InitializeDataBindingsForInputText(string textPropertyName)
        {
            var inputTextBindingsDictionary = new Dictionary<Control, string>();
            inputTextBindingsDictionary.Add(_courseActivateComboBox, nameof(_courseManagementFormPresentationModel.CourseActivateOrNot));
            inputTextBindingsDictionary.Add(_courseIdTextBox, nameof(_courseManagementFormPresentationModel.CourseId));
            inputTextBindingsDictionary.Add(_courseNameTextBox, nameof(_courseManagementFormPresentationModel.CourseName));
            inputTextBindingsDictionary.Add(_courseStageTextBox, nameof(_courseManagementFormPresentationModel.CourseStage));
            inputTextBindingsDictionary.Add(_courseCreditsTextBox, nameof(_courseManagementFormPresentationModel.CourseCredits));
            inputTextBindingsDictionary.Add(_courseTeachingAssistantTextBox, nameof(_courseManagementFormPresentationModel.CourseTeachingAssistant));
            inputTextBindingsDictionary.Add(_courseTeacherTextBox, nameof(_courseManagementFormPresentationModel.CourseTeacher));
            inputTextBindingsDictionary.Add(_courseLanguageTextBox, nameof(_courseManagementFormPresentationModel.CourseLanguage));
            inputTextBindingsDictionary.Add(_courseNoteTextBox, nameof(_courseManagementFormPresentationModel.CourseNote));
            inputTextBindingsDictionary.Add(_courseElectiveComboBox, nameof(_courseManagementFormPresentationModel.CourseRequiredOrElective));
            inputTextBindingsDictionary.Add(_courseHoursComboBox, nameof(_courseManagementFormPresentationModel.CourseHours));
            foreach (var pair in inputTextBindingsDictionary)
            {
                AddDataBinding(pair.Key, textPropertyName, pair.Value);
            }
            AddDataBinding(_classComboBox, nameof(_classComboBox.SelectedValue), nameof(_courseManagementFormPresentationModel.Class));
        }

        /// <summary>
        /// 設定 TextChanged Event Binding
        /// </summary>
        internal void InitializeDataBindingsForInputTextChangedEvent()
        {
            var inputTextChangedEventBindingsDictionary = new Dictionary<Control, EventHandler>();
            inputTextChangedEventBindingsDictionary.Add(_courseActivateComboBox, ListenCourseActivateComboBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseIdTextBox, ListenCourseIdTextBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseNameTextBox, ListenCourseNameTextBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseStageTextBox, ListenCourseStageTextBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseCreditsTextBox, ListenCourseCreditsTextBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseTeachingAssistantTextBox, ListenCourseTeachingAssistantTextBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseTeacherTextBox, ListenCourseTeacherTextBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseLanguageTextBox, ListenCourseLanguageTextBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseNoteTextBox, ListenCourseNoteTextBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseElectiveComboBox, ListenCourseElectiveComboBoxOnTextChanged);
            inputTextChangedEventBindingsDictionary.Add(_courseHoursComboBox, ListenCourseHoursComboBoxOnTextChanged);
            foreach (var pair in inputTextChangedEventBindingsDictionary)
            {
                pair.Key.TextChanged += pair.Value;
            }
        }

        /// <summary>
        /// 綁定 TextBox/ComboBox 的 Enabled 狀態
        /// </summary>
        internal void AddDataBindingsForNestedInputs(Control control, string propertyName, string memberName)
        {
            foreach (var input in control.Controls.OfType<TextBox>())
            {
                AddDataBinding(input, propertyName, memberName);
            }

            foreach (var input in control.Controls.OfType<ComboBox>())
            {
                AddDataBinding(input, propertyName, memberName);
            }
        }

        /// <summary>
        /// 綁定 Data
        /// </summary>
        internal void AddDataBinding(Control control, string propertyName, string memberName)
        {
            control.DataBindings.Add(
                propertyName, _courseManagementFormPresentationModel, memberName);
        }
    }
}
